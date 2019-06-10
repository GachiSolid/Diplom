using CreditBureauWPF.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xceed.Words.NET;

namespace CreditBureauWPF.ViewModels
{
    public class AppealWindowViewModel
    {
        public Action Close { get; set; }
        UserContext db;
        string full, name;
        int id, value;
        public string Reason { get; set; }
        public string Info { get; set; }
        public string Organization { get; set; }
        int actcount = 0;
        int closecount = 0;
        int appealscount = 0;
        int n = 1;
        string gender;
        string trueReason;
        public string filePath;

        public AppealWindowViewModel(string _full, string _name, int _id, int _value)
        {
            full = _full;
            name = _name;
            id = _id;
            value = _value;
        }

        public ICommand ReportClick
        {
            get
            {
                return new RelayCommand(
                    (obj) =>
                    {
                        CreateDocument();

                        var person = db.People.SingleOrDefault(p => p.Id.Equals(id));
                        if (Reason == "Запрос банка" || Reason == "Запрос работадателя")
                        {
                            trueReason = Reason + ": " + Organization;
                        }
                        else if (Reason == "Другая причина")
                        {
                            trueReason = Reason + ": " + Info;
                        }
                        else trueReason = Reason;
                        Appeal appealtable = new Appeal { Date = DateTime.Now, Reason = trueReason, PersonId = id, Person = person };
                        db.Appeals.Add(appealtable);
                        db.SaveChanges();
                        Close();
                    },
                    (obj) =>
                    {
                        return !string.IsNullOrWhiteSpace(Reason);
                    }
                    );
            }
        }

        private void CreateDocument()
        {

            db = new UserContext();
            var person = db.People.FirstOrDefault(p => p.Id.Equals(id));

            string fileName = id + "_" + person.Familiya + ".docx";
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Документ Word (*.docx)|*.docx";
            save.FileName = fileName;
            if (save.ShowDialog() == DialogResult)
            {
                filePath = save.FileName;
                var doc = DocX.Create(filePath);

                string title1 = full;

                Formatting titleFormat1 = new Formatting();

                titleFormat1.FontFamily = new Xceed.Words.NET.Font("Times new roman");
                titleFormat1.Size = 20D;
                titleFormat1.Position = 40;

                Paragraph maintitle = doc.InsertParagraph(title1, false, titleFormat1);
                maintitle.Alignment = Alignment.center;

                string title2 = "Кредитный рейтинг: " + Convert.ToString(value) + "/10";

                Formatting titleFormat2 = new Formatting();
                titleFormat2.FontFamily = new Xceed.Words.NET.Font("Times new roman");
                titleFormat2.Size = 18D;
                titleFormat2.Position = 40;

                Paragraph ratingtitle = doc.InsertParagraph(title2, false, titleFormat1);
                ratingtitle.Alignment = Alignment.center;

                if (person.Gender == "М") { gender = "Мужской"; }
                else { gender = "Женский"; }

                string infotext = "Код субъекта: " + person.Id + Environment.NewLine +
                    "Фамилия: " + person.Familiya + Environment.NewLine +
                    "Имя: " + person.Name + Environment.NewLine +
                    "Отчество: " + person.Otchestvo + Environment.NewLine +
                    "Пол: " + gender + Environment.NewLine +
                    "Страховой номер: " + person.Snils + Environment.NewLine;

                Formatting textParagraphFormat = new Formatting();
                textParagraphFormat.FontFamily = new Xceed.Words.NET.Font("Times new roman");
                textParagraphFormat.Size = 16D;

                doc.InsertParagraph(infotext, false, textParagraphFormat);

                var activecredits = db.CreditBanks.Where(c => c.PersonId.Equals(id) && c.Status.Equals(false));
                if (activecredits.Any())
                {
                    foreach (CreditBank c in activecredits)
                    {
                        actcount++;
                    }

                    string title3 = "Активные кредиты";

                    Paragraph activetitle = doc.InsertParagraph(title3, false, titleFormat2);
                    activetitle.Alignment = Alignment.center;

                    Table active = doc.AddTable(actcount + 1, 5);
                    active.Alignment = Alignment.center;

                    active.Rows[0].Cells[0].Paragraphs.First().Append("Банк");
                    active.Rows[0].Cells[1].Paragraphs.First().Append("Сумма");
                    active.Rows[0].Cells[2].Paragraphs.First().Append("Процентная ставка");
                    active.Rows[0].Cells[3].Paragraphs.First().Append("Дата взятия кредита");
                    active.Rows[0].Cells[4].Paragraphs.First().Append("Срок");

                    foreach (CreditBank c in activecredits)
                    {

                        active.Rows[n].Cells[0].Paragraphs.First().Append(c.Bank);
                        active.Rows[n].Cells[1].Paragraphs.First().Append(Convert.ToString(c.Sum) + " руб.");
                        active.Rows[n].Cells[2].Paragraphs.First().Append(Convert.ToString(c.Percent) + "%");
                        active.Rows[n].Cells[3].Paragraphs.First().Append(c.Begin.Value.ToString("dd.MM.yyyy"));
                        active.Rows[n].Cells[4].Paragraphs.First().Append(c.Mounth);
                        n++;
                    }
                    doc.InsertTable(active);
                    n = 1;
                }

                var closecredits = db.CreditBanks.Where(c => c.PersonId.Equals(id) && c.Status.Equals(true));
                if (closecredits.Any())
                {
                    foreach (CreditBank c in closecredits)
                    {
                        closecount++;
                    }

                    string title4 = Environment.NewLine + "Закрытые кредиты";

                    Paragraph closetitle = doc.InsertParagraph(title4, false, titleFormat2);
                    closetitle.Alignment = Alignment.center;

                    Table close = doc.AddTable(closecount + 1, 6);
                    close.Alignment = Alignment.center;

                    close.Rows[0].Cells[0].Paragraphs.First().Append("Банк");
                    close.Rows[0].Cells[1].Paragraphs.First().Append("Сумма");
                    close.Rows[0].Cells[2].Paragraphs.First().Append("Процентная ставка");
                    close.Rows[0].Cells[3].Paragraphs.First().Append("Дата взятия кредита");
                    close.Rows[0].Cells[4].Paragraphs.First().Append("Срок");
                    close.Rows[0].Cells[5].Paragraphs.First().Append("Описание");

                    foreach (CreditBank c in closecredits)
                    {

                        close.Rows[n].Cells[0].Paragraphs.First().Append(c.Bank);
                        close.Rows[n].Cells[1].Paragraphs.First().Append(Convert.ToString(c.Sum) + " руб.");
                        close.Rows[n].Cells[2].Paragraphs.First().Append(Convert.ToString(c.Percent) + "%");
                        close.Rows[n].Cells[3].Paragraphs.First().Append(c.Begin.Value.ToString("dd.MM.yyyy"));
                        close.Rows[n].Cells[4].Paragraphs.First().Append(c.Mounth);
                        close.Rows[n].Cells[5].Paragraphs.First().Append(c.Description);
                        n++;
                    }

                    doc.InsertTable(close);
                    n = 1;
                }

                var appeals = db.Appeals.Where(c => c.PersonId.Equals(id));
                if (appeals.Any())
                {
                    foreach (Appeal c in appeals)
                    {
                        appealscount++;
                    }

                    string title5 = Environment.NewLine + "Обращения в бюро кредитных историй";

                    Paragraph appealtitle = doc.InsertParagraph(title5, false, titleFormat2);
                    appealtitle.Alignment = Alignment.center;

                    Table app = doc.AddTable(appealscount + 1, 2);
                    app.Alignment = Alignment.center;

                    app.Rows[0].Cells[0].Paragraphs.First().Append("Причина");
                    app.Rows[0].Cells[1].Paragraphs.First().Append("Дата обращения");

                    foreach (Appeal c in appeals)
                    {
                        app.Rows[n].Cells[0].Paragraphs.First().Append(c.Reason);
                        app.Rows[n].Cells[1].Paragraphs.First().Append(c.Date.Value.ToString("dd.MM.yyyy"));
                        n++;
                    }

                    doc.InsertTable(app);
                }

                doc.Save();
                Process.Start("WINWORD.EXE", filePath);
            }
        }
    }
}
