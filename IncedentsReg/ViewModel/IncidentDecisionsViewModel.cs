using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IncedentsReg.Model;
using Kurs.Model;
using Kurs.View;

namespace IncedentsReg.ViewModel
{
    internal class IncidentDecisionsViewModel : INotifyPropertyChanged
    {
        ModelContext db = new ModelContext();
        private IncidentDecisions window;
        private IncidentDecisions selectedBuyer;
        public ObservableCollection<IncidentDecisions> IncidentDecisionsList { get; set; }
        public IncidentDecisions SelectedBuyer
        {
            get { return selectedBuyer; }
            set
            {
                selectedBuyer = value;
                OnPropertyChanged("SelectedBuyer");
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
                      IncidentDecisions IncidentDecisions = obj as IncidentDecisions;
                      IncidentDecisions.report_id = window.report_id;
                      IncidentDecisions.decision = window.decision;
                      db.Buyer.Add(IncidentDecisions);
                      db.SaveChanges();

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
                      IncidentDecisions byuer = obj as IncidentDecisions;
                      IncidentDecisions.Remove(byuer);
                      if (byuer == null) return;
                      db.Buyer.Remove(byuer);
                      db.SaveChanges();
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
                      IncidentDecisions IncidentDecisions = obj as IncidentDecisions;
                      IncidentDecisions.report_id = window.report_id;
                      IncidentDecisions.decision = window.decision;
                      db.Entry(IncidentDecisions).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
                      db.SaveChanges();
                  }));
            }
        }
        public BuyerViewModel(BuyerWindow window)
        {
            this.window = window;
            BuyersList = new ObservableCollection<Buyer>();
            db.Database.EnsureCreated();
            db.Buyer.Load();
            BuyersList = db.Buyer.Local.ToObservableCollection();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
