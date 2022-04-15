using BIT_DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT_DesktopApp.ViewModels
{
    public class ContractorViewModel
    {
        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;

        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set { _contractors = value; }
        }

        public Contractor SelectedContractor
        {
            get { return _selectedContractor; } 
            set { _selectedContractor = value; }
        }
        public ContractorViewModel()
        {
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
        }
    }
}
