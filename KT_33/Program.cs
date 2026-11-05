using System;
using System.Collections.Generic;

namespace KT_33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>
            {
                { "Анна", "8-900-111-22-33" },
                { "Иван", "8-900-444-55-66" }
            };

            Console.WriteLine("=== Исходная телефонная книга ===");
            PrintPhoneBook(phoneBook);

            Console.WriteLine("\n--- Поиск в телефонной книге ---");
            SearchContact(phoneBook, "Анна");
            SearchContact(phoneBook, "Алексей");

            Console.WriteLine("\n--- Обновление номера ---");
            string updateName = "Анна";
            if (phoneBook.ContainsKey(updateName))
            {
                phoneBook[updateName] = "8-999-000-00-00";
                Console.WriteLine($"Номер для '{updateName}' успешно обновлен.");
            }
            SearchContact(phoneBook, updateName);

            Console.WriteLine("\n--- Удаление записей (Remove) ---");
            string removeExisting = "Иван";
            bool removed1 = phoneBook.Remove(removeExisting);
            Console.WriteLine($"Удаление '{removeExisting}': {removed1} (ожидается True)");

            string removeMissing = "Петр";
            bool removed2 = phoneBook.Remove(removeMissing);
            Console.WriteLine($"Удаление '{removeMissing}': {removed2} (ожидается False)");

            Console.WriteLine("\n=== Телефонная книга после всех операций ===");
            PrintPhoneBook(phoneBook);
        }

        static void SearchContact(Dictionary<string, string> book, string name)
        {
            if (book.TryGetValue(name, out string phoneNumber))
            {
                Console.WriteLine($"Найден контакт: {name} — Номер: {phoneNumber}");
            }
            else
            {
                Console.WriteLine($"Контакт '{name}' не найден в телефонной книге.");
            }
        }

        static void PrintPhoneBook(Dictionary<string, string> book)
        {
            if (book.Count == 0)
            {
                Console.WriteLine("Телефонная книга пуста.");
                return;
            }

            foreach (KeyValuePair<string, string> pair in book)
            {
                Console.WriteLine($"Имя: {pair.Key}, Телефон: {pair.Value}");
            }
        }
    }
}