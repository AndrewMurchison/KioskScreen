using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace kiosk.vInfoModel
{
    class ModalModel
    {
    }
        public class modalwindow : INotifyPropertyChanged
        {
            private String instr;
            private String video;
            

           
           


            public string Instr
            {
                get
                {
                    return instr;
                }
                set
                {
                    if (instr != value)
                    {
                        instr = value;
                        RaisePropertyChanged("Instr");
                    }
                }
            }

            public string Video
            {
                get
                {
                    return video;
                }
                set
                {
                    if (video != value)
                    {
                        video = value;
                        RaisePropertyChanged("Video");
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaisePropertyChanged(string property)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property));
                }
            }
        }
    
}
