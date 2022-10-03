using System;
using System.Collections.Generic;

namespace homework
{
    class Program
    {
        static int ActiveListFrequency = 0;
        static List<string> ListNotes = new List<string> { "C", "C#", "D", "Eb", "E", "F", "F#", "G", "G#", "А", "Bb", "B" };
        static List<int[]> ListFrequency = new List<int[]> {
            new int[] { 65, 69, 73, 77, 82, 87, 92, 98, 103, 110, 116, 123 },
            new int[] { 130, 138, 146, 155, 164, 174, 185, 196, 207, 220, 233, 246 },
            new int[] { 261, 277, 293, 311, 329, 349, 370, 392, 415, 440, 466, 493 },
            new int[] { 523, 554, 587, 622, 659, 698, 740, 784, 830, 880, 932, 987 },
            new int[] { 1047, 1109, 1175, 1245, 1319, 1397, 1480, 1568, 1661, 1760, 1865, 1976 },
            new int[] { 2093, 2217, 2349, 2489, 2637, 2794, 2960, 3136, 3322, 3520, 3729, 3951 },
            new int[] { 4186, 4435, 4699, 4978, 5274, 5588, 5920, 6272, 6645, 7040, 7459, 7902 },
        };
        static List<ConsoleKey> ButtonsOctava = new List<ConsoleKey> { 
            ConsoleKey.F1,
            ConsoleKey.F2,
            ConsoleKey.F3,
            ConsoleKey.F4,
            ConsoleKey.F5,
            ConsoleKey.F6,
            ConsoleKey.F7
        };
        static List<ConsoleKey> Buttons = new List<ConsoleKey> {
            ConsoleKey.Q,
            ConsoleKey.W,
            ConsoleKey.E,
            ConsoleKey.R,
            ConsoleKey.T,
            ConsoleKey.Y,
            ConsoleKey.U,
            ConsoleKey.I,
            ConsoleKey.O,
            ConsoleKey.P,
            ConsoleKey.A,
            ConsoleKey.S
        };

        static void Main(string[] args) => Open(); // запуск
        static void Open()
        {
            Console.Clear(); // очистить консоль
            Console.WriteLine($"Переключение между октавами - {String.Join(", ", ButtonsOctava.ToArray())}");
            Console.WriteLine($"Откава: {ActiveListFrequency}");
            LoadListButtons(); // выводим в консоль список кнопок
            InputKey(Console.ReadKey()); // обращаемся к функции -> InputKey -> чтобы отловить нажатую кнопку на клавиатуре
        }
        static void InputKey(ConsoleKeyInfo key) // Ловим нажатую кнопку
        {
            if (key.Key == ConsoleKey.Escape) Open(); // если нажимаем esc подгружаем главное окно
            else
            {
                int OctavaId = ButtonsOctava.FindIndex(e => { return e == key.Key; }); // находим id октавы
                if (OctavaId != -1) ActiveListFrequency = OctavaId; // переключние между октавами
                PlaySoud(key); // воспроизводим звук
            }
        }
        static void LoadListButtons() // вывести в консоль все кнопки и их ноту
        {
            Console.Write($"\nТаблица кнопок и нот\n"); // выводим в консоль
            for (int i = 0; i < Buttons.Count; i++) // перебираем кнопки
            {
                ConsoleKey Key = Buttons[i]; // находим кнопку
                string NoteName = ListNotes[i]; // находим ноту
                int Frequency = ListFrequency[ActiveListFrequency][i];
                Console.Write($"Button: {Key} -> {NoteName} -> Гц: {Frequency}\n"); // выводим в консоль
            }
        }
        static void PlaySoud(ConsoleKeyInfo key, int duration = 100) // воспроизвести звук
        {
            int ButtonId = Buttons.FindIndex(e => { return e == key.Key; }); // находим id кнопки
            if(ButtonId != -1) Console.Beep(ListFrequency[ActiveListFrequency][ButtonId], duration); // воспроизводим звук -> список октав -> id кнопки -> 
            Open();
        }
    }
}
