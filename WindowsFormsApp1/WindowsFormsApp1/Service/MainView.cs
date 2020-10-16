using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using WindowsFormsApp1;
using System.Windows;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;


namespace WindowsFormsApp1.ProgramView
{
    public class MainView : ApplicationContext
    {
        private NotifyIcon trayIcon; // переменная класса NotifyIcon
        private static string icon = @"icons/icon.ico"; // Расположение иконки 

        public MainView()
        {
            trayIcon = new NotifyIcon() //Конструктор создания иконки и её параметра в трее
            {
                Icon = new Icon(icon),  // Присвоение картинки элементу TrayIcon
                ContextMenu = new ContextMenu(new MenuItem[] { // Создание контекстного меню
                new MenuItem("Exit", Exit) // Добавление элемента Exit в конт. меню 
            }),
                Visible = true // Видимость иконки
            };
            Alarm(trayIcon); // Вызов метода Alarm
        }

        void Exit(object sender, EventArgs e) // По обращениею в exit скрывается иконка и закрывается программа
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        async void Alarm(NotifyIcon trayIcon) // Заглушка метода _Alarm
        {
            await Task.Run(() => _Alarm()); // Создание задачи в номов потоке
        }

        void _Alarm() // Вывод информации на экран согласно условию
        {
            while (true)
            {
                if (DateTime.Now.Minute % 2 == 0 && DateTime.Now.Second == 1)
                {
                    this.trayIcon.BalloonTipText = "Хорошо поспал"; // Текст всплывающего уведомления
                    this.trayIcon.BalloonTipIcon = ToolTipIcon.Info; // Информации о всплывающем окне
                    this.trayIcon.ShowBalloonTip(30000); // Длительность всплывающего уведомления
                }
            }
        }
    }
}
