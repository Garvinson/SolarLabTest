using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleMax
{
    class DbService
    {
        public DataBaseContext context;

        public DbService()
        {
            try
            {
                context = new DataBaseContext();
            } catch (Exception e)
            {
                Console.Error.WriteLine("Не удалось подключиться к БД: " + e.Message);
                Environment.Exit(0);
            }

        }

        public List<Task> GetTasks()
        {
            return context.AllTasks.ToList();
        }

        public void AddTask(Task task)
        {
            context.AllTasks.Add(task);
            context.SaveChanges();
        }

        public Task GetTaskById(int id)
        {
            return context.AllTasks.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateTask(Task task)
        {
            context.Update(task);
            context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            context.Remove(task);
            context.SaveChanges();
        }
    }
}
