using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using kiosk.vInfoModel;

namespace kiosk.vInfoViewModel
{
    public class ModalViewModel
    {
        public ObservableCollection<modalwindow> Modal
        {
            get;
            set;
        }

        public void LoadCreditModal()
        {
            ObservableCollection<modalwindow> modal = new ObservableCollection<modalwindow>();

            modal.Add(new modalwindow { Instr="Please swipe your Debit/Credit card as shown in the video and then follow the instructions displayed on the card processing unit.", Video= "../../Img/credit.avi" });


           Modal = modal;
        }

        public void LoadCashModal()
        {
            ObservableCollection<modalwindow> modal = new ObservableCollection<modalwindow>();

            modal.Add(new modalwindow { Instr = "Please insert money as shown in the video to complete the transaction.", Video = "../../Img/cash.avi" });


            Modal = modal;
        }
    }
}
