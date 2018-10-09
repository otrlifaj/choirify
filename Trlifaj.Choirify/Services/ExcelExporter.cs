using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF;
using NPOI.XSSF.UserModel;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.Enums;
using Trlifaj.Choirify.Models.ManyToMany;

namespace Trlifaj.Choirify.Services
{
    public class ExcelExporter
    {
        public static XSSFWorkbook ExportRegistrations(List<Singer> singers, List<EventRegistration> registrations, Event @event, bool registered, bool unregistered, bool withoutRegistration)
        {
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet(@event.Name);
            var row = sheet.CreateRow(0);
            for (int i = 0; i < RegistrationRow.CellHeader.Count; i++)
            {
                row.CreateCell(i).SetCellValue(RegistrationRow.CellHeader[i]);
            }

            var registrationRows = TransformRegistrations(singers, registrations, registered, unregistered, withoutRegistration);
            for (int i = 0; i < registrationRows.Count; i++)
            {
                row = sheet.CreateRow(i + 1);
                for (int j = 0; j < registrationRows[i].CellValues.Count; j++)
                {
                    row.CreateCell(j).SetCellValue(registrationRows[i].CellValues[j]);
                }
            }
            return workbook;
        }

        private static List<RegistrationRow> TransformRegistrations(List<Singer> singers, List<EventRegistration> registrations, bool registered, bool unregistered, bool withoutRegistration)
        {
            List<RegistrationRow> excelRows = new List<RegistrationRow>();

            var positiveRegistrations = registrations.Where(r => r.Answer == true).ToList();
            var singersWithPositiveRegistration = singers.Where(s => positiveRegistrations.Any(r => r.SingerId == s.Id)).OrderBy(s => s.VoiceGroup).ToList();
            var negativeRegistrations = registrations.Where(r => r.Answer == false).ToList();
            var singersWithNegativeRegistration = singers.Where(s => negativeRegistrations.Any(r => r.SingerId == s.Id)).OrderBy(s => s.VoiceGroup).ToList();
            var singersWithoutRegistration = singers.Where(s => !registrations.Any(r => r.SingerId == s.Id)).OrderBy(s => s.VoiceGroup).ToList();

            if (registered)
            {
                foreach (var singer in singersWithPositiveRegistration)
                {
                    var registration = positiveRegistrations.FirstOrDefault(er => er.SingerId == singer.Id);
                    var registrationRow = new RegistrationRow(singer.FirstName, singer.Surname, singer.PhoneNumber, singer.Email, singer.NumberOfIDCard, singer.Address, singer.DateOfBirth, singer.VoiceGroup.Value, registration.Answer, registration.Comment, registration.RegistrationDate);
                    excelRows.Add(registrationRow);
                }
            }

            if (unregistered)
            {
                foreach (var singer in singersWithNegativeRegistration)
                {
                    var registration = negativeRegistrations.FirstOrDefault(er => er.SingerId == singer.Id);
                    var registrationRow = new RegistrationRow(singer.FirstName, singer.Surname, singer.PhoneNumber, singer.Email, singer.NumberOfIDCard, singer.Address, singer.DateOfBirth, singer.VoiceGroup.Value, registration.Answer, registration.Comment, registration.RegistrationDate);
                    excelRows.Add(registrationRow);
                }
            }

            if (withoutRegistration)
            {
                foreach (var singer in singersWithoutRegistration)
                {
                    var registrationRow = new RegistrationRow(singer.FirstName, singer.Surname, singer.PhoneNumber, singer.Email, singer.NumberOfIDCard, singer.Address, singer.DateOfBirth, singer.VoiceGroup.Value);
                    excelRows.Add(registrationRow);
                }
            }

            return excelRows;
        }
    }


    class RegistrationRow
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string NumberOfIdCard { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Birth
        {
            get
            {
                return DateOfBirth.ToString("d.M.yyyy");
            }
        }
        public VoiceGroup Voice { get; set; }
        public string VoiceString
        {
            get
            {
                return Voice.ToString();
            }
        }
        public bool? IsRegistered { get; set; }
        public string Registration
        {
            get
            {
                if (IsRegistered == true)
                {
                    return "Přihlášen";
                }
                else if (IsRegistered == false)
                {
                    return "Odhlášen";
                }
                else
                {
                    return "Bez vyjádření";
                }
            }
        }
        public string Comment { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RegisteredOn
        {
            get
            {
                if (RegistrationDate.HasValue)
                {
                    return RegistrationDate.Value.ToString("d.M.yyyy H:mm");
                }
                else return "-";
            }
        }
        public RegistrationRow(string name, string surname, string phone, string email, string numberOfIdCard, string address, DateTime dateOfBirth, VoiceGroup voice, bool? isRegistered = null, string comment = null, DateTime? registrationDate = null)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Email = email;
            NumberOfIdCard = numberOfIdCard;
            Address = address;
            DateOfBirth = dateOfBirth;
            Voice = voice;
            IsRegistered = isRegistered;
            Comment = comment ?? "";
            RegistrationDate = registrationDate;
        }

        public List<string> CellValues => new List<string>
        {
            Name, Surname, Birth, Phone, Email, NumberOfIdCard, Address, VoiceString, Registration, Comment, RegisteredOn
        };

        public static List<string> CellHeader => new List<string>
        {
            "Jméno", "Příjmení", "Datum narození", "Telefon", "Email", "Číslo OP", "Adresa", "Hlas", "Účast", "Poznámka", "Datum přihlášení"
        };
    }



}
