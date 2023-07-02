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
    public class Persons : INotifyPropertyChanged
    {
        private string person_number;
        public string Person_number
        {
            get { return person_number; }
            set { person_number = value; OnPropertyChanged("Person_number"); }
        }

        private string last_name;
        public string Last_name
        {
            get { return last_name; }
            set { last_name = value; OnPropertyChanged("Last_name"); }
        }

        private string first_name;
        public string First_name
        {
            get { return first_name; }
            set { first_name = value; OnPropertyChanged("First_name"); }
        }

        private string middle_name;
        public string Middle_name
        {
            get { return middle_name; }
            set { middle_name = value; OnPropertyChanged("Middle_name"); }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }


                private string convictions;
        public string Convictions
        {
            get { return convictions; }
            set { convictions = value; OnPropertyChanged("Convictions"); }
        }
        public void Insert()
        {
            using (var connection = new SqliteConnection("Data Source=incedents.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO conference_participants (Report_id, Person_id, Role) VALUES ('{Person_number}', '{Last_name}', '{First_name}', '{Middle_name}', '{Address}', '{Convictions}')";
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
                command.CommandText = $"INSERT INTO conference_participants (Report_id, Person_id, Role) VALUES ('{Person_number}', '{Last_name}', '{First_name}', '{Middle_name}', '{Address}', '{Convictions}')";
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
