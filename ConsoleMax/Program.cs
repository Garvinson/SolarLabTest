using System;
using System.Collections.Generic;

namespace ConsoleMax
{
    class Program
    {
        static DbService dbservice;

        static void Main(string[] args)
        {
            dbservice = new DbService();
            while (true)
            {
                Print();
                Console.WriteLine("1. Добавить");
                Console.WriteLine("2. Изменить");
                Console.WriteLine("3. Удалить");
                Console.WriteLine("4. Отметить выполненное");
                Console.WriteLine("0. Выход");

                var userChoise = Console.ReadLine();
                int userChoiseInteger;

                if (int.TryParse(userChoise, out userChoiseInteger))
                {
                    switch (userChoiseInteger)
                    {
                        case 1:
                            Console.WriteLine("Введите задание:");
                            var textOfTask = Console.ReadLine().Trim();
                            Console.WriteLine("Введите дэдлайн в формате DD.MM.YYYY:");
                            var deadlineOfTask = Console.ReadLine();
                            var deadline = DateTime.Parse(deadlineOfTask);
                        
                            dbservice.AddTask(new Task() {Text = textOfTask, Deadline = deadline, IsDone = false});
                            break;
                        case 2:
                            Console.WriteLine("Введите номер задания для изменения:");
                            var indexToEdit = int.Parse(Console.ReadLine());

                            var tempTask = dbservice.GetTaskById(indexToEdit);

                            if (tempTask == null)
                            {
                                Console.WriteLine("Не найден элемент с id " + indexToEdit);
                                break;
                            }
                        
                            Console.WriteLine("Введите новое название (" + tempTask.Text + "):");
                            tempTask.Text = Console.ReadLine();
                        
                            Console.WriteLine("Введите новый дэдлайн (" + tempTask.Deadline.ToString("dd/MM/yyyy") + "):");
                            tempTask.Deadline = DateTime.Parse(Console.ReadLine());

                            dbservice.UpdateTask(tempTask);
                            break;
                        case 3:
                            Console.WriteLine("Введите номер задания:");
                            var indexToRemove = int.Parse(Console.ReadLine());

                            var removeTask = dbservice.GetTaskById(indexToRemove);

                            if (removeTask == null)
                            {
                                Console.WriteLine("Не найден элемент с id " + indexToRemove);
                                break;
                            }

                            dbservice.DeleteTask(removeTask);
                            break;
                        case 4:
                            Console.WriteLine("Введите номер выполненного задания:");
                            var indexToDone = int.Parse(Console.ReadLine());

                            var doneTask = dbservice.GetTaskById(indexToDone);

                            if (doneTask == null)
                            {
                                Console.WriteLine("Не найден элемент с id " + indexToDone);
                                break;
                            }

                            doneTask.IsDone = true;

                            dbservice.UpdateTask(doneTask);
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("\nНапишите цифру!\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Введите число.");
                }               
            }
        }

        private static void Print()
        {
            var list = dbservice.GetTasks();
            Console.WriteLine();

            if (list.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
            }
            for (var i = 0; i < list.Count; i++)
            {
                
                Console.WriteLine(list[i].Id + ". " + list[i].Text + "\t\tдо " + list[i].Deadline.ToString("dd/MM/yyyy") + "\t" + (list[i].IsDone ? "Выполнено" : "Не выполнено"));
            }
            Console.WriteLine();
        } 
    }
}