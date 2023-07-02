using IncedentsReg.Model;
using IncedentsReg.View;
using Kurs.Model;
using Microsoft.Data.Sqlite;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Media.Imaging;
using IncidentReports = IncedentsReg.Model.IncidentReports;

namespace IncedentsReg.ViewModel
{
    internal class IncedentsViewModel : INotifyPropertyChanged
    {
        private IncedentsViewModel window;
        private IncedentsViewModel SelectedIncidentReports;
        public ObservableCollection<IncedentsViewModel> IncedentsList { get; set; }
        public IncedentsViewModel Selectedincedents
        {
            get { return Selectedincedents; }
            set
            {
                Selectedincedents = value;
                OnPropertyChanged("Selectedincedents");
            }
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      IncedentsViewModel cp = new IncedentsViewModel();
                      cp.report_id = window.report_id.Text;
                      cp.decision = window.decision.Text;
                      IncedentsList.Add(cp);
                  }));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      IncedentsViewModel cps = obj as IncedentsViewModel;
                      cps.Delete(cps.Id_Conference);
                      IncedentsList.Remove(cps);
                  }));
            }
        }
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand(obj =>
                  {
                      IncidentDecisions cup = obj as IncidentDecisions;
                      cup.report_id = window.report_id.Text;
                      cup.decision = window.decision.Text;
                      IncedentsList.Add(cup);
                  }));
            }
        }
        public IncedentsViewModel(MainWindow window)
        {
            this.window = window;
            IncedentsViewModel = new ObservableCollection<IncedentsViewModel>();
            using (var connection = new SqliteConnection("Data Source=incedents.db"))
            {
                connection.Open();
                SqliteCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM conference_participants";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            IncidentReports cp = new IncidentReports();
                            cp.registration_number = reader.GetInt32(0);
                            cp.registration_date = reader.GetValue(1).ToString();
                            cp.summary = reader.GetValue(2).ToString();
                            IncedentsList.Add(cp);
                        }
                    }
                }
            }
        }

        public IncedentsViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
