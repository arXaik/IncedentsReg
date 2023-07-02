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
    public class IncidentDecisions : INotifyPropertyChanged
    {
        public string report_id;
        public string Report_id
        {
            get { return report_id; }
            set { report_id = value; OnPropertyChanged("Report_id"); }
        }

        public string decision;
        public string Decision
        {
            get { return decision; }
            set { decision = value; OnPropertyChanged("Decision"); }
        }
        public void Insert()
        {
            using (var connection = new SqliteConnection("Data Source=incedents.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO conference_participants (Report_id, Decision) VALUES ('{report_id}', '{decision}')";
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
                command.CommandText = $"INSERT INTO conference_participants (Report_id, Decision) VALUES ('{report_id}', '{decision}')";
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
