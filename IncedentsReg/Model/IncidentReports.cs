using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace IncedentsReg.Model
{
    public class IncidentReports : INotifyPropertyChanged
    {
        public string? registration_number;
        public string Registration_number
        {
            get { return registration_number; }
            set { registration_number = value; OnPropertyChanged("Registration_number"); }
       }

        public string? registration_date;
        public string Registration_date
        {
            get { return registration_date; }
            set { registration_date = value; OnPropertyChanged("Registration_date"); }
        }
        public string? summary;
        public string Summary
        {
            get { return summary; }
            set { summary = value; OnPropertyChanged("Summary"); }
        }
        public void Insert()
        {
            using (var connection = new SqliteConnection("Data Source=incedents.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO conference_participants (Registration_number, Registration_date,Summary) VALUES ('{registration_number}', '{registration_date}','{summary}')";
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int Id)
        {
            using (var connection = new SqliteConnection("Data Source=incedents.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"Delete from IncidentReports where Id={Id}";
                command.ExecuteNonQuery();
            }
        }
        public void Update(int Id)
        {
            using (var connection = new SqliteConnection("Data Source=incedents.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"UPDATE conference_participants SET Registration_number='{registration_number}',Registration_date='{registration_date}',Summary='{summary}'";
                command.ExecuteNonQuery();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
