using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp2
{
    class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string CountChange
        {
            get
            {
                return Model.count.ToString();
            }
        }
        public List<string> ComboChange
        {
            get
            {
                return Model.dataList;
            }
        }
        int cbIndex = -1;
        public int IndexSelected
        {
            set
            {
                // индек - это необходимое значение, которое нужно получить
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));
            }
        }
        public string CBIndex
        {
            get
            {
                if (cbIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.dataList[cbIndex];
                }
                
            }
        }
        // класс, который реализазует интерфейс ICommand
        public RoutedCommand Command { get; set; } = new RoutedCommand();
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Model.count++;
            PropertyChanged(this, new PropertyChangedEventArgs("CountChange"));
        }
        public CommandBinding bind; // создание объекта для привязки команды
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }     
}
