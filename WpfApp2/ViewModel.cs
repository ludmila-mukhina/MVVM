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
        public event PropertyChangedEventHandler PropertyChanged; // событие. которое реагирует на изменение свойст
        public string CountChange // свойство для отображения числа в TextBlock
        {
            get
            {
                return Model.count.ToString();
            }
        }
        public List<string> ComboChange // свойство для заполнения Combobox
        {
            get
            {
                return Model.dataList;
            }
        }
        int cbIndex = -1;
        public int IndexSelected // свойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                // индек - это необходимое значение, которое нужно получить
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));  // событие, которое реагирует на изменение свойства
            }
        }
        public string CBIndex // свойство для отображения фамилии в Combobox
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
        
        // обработчик события для Command (увеличение значения числа на 1)
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Model.count++;
            PropertyChanged(this, new PropertyChangedEventArgs("CountChange"));
        }
        public CommandBinding bind; // создание объекта для привязки команды
        public ViewModel()
        {
            bind = new CommandBinding(Command);  // инициализация объекта для привязки данных
            bind.Executed += Command_Executed;  // добавление обработчика событий
        }
    }     
}
