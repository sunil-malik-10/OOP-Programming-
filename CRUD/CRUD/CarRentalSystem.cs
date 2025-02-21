using System;
using System.Collections.Generic;
using System.IO;

class CarRentalSystem
{
    static string filePath = "CarRecords.txt";

    static void Main()
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("\nCar Rental Management System");
            Console.WriteLine("1. Add Car");
            Console.WriteLine("2. View Cars");
            Console.WriteLine("3. Update Car");
            Console.WriteLine("4. Delete Car");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    AddCar();
                    break;
                case 2:
                    Console.Clear();
                    ViewCars();
                    break;
                case 3:
                    Console.Clear();
                    UpdateCar();
                    break;
                case 4:
                    Console.Clear();
                    DeleteCar();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again!");
                    break;
            }
        } while (choice != 5);
    }

    static void AddCar()
    {
        Console.Write("Enter Car ID: ");
        string id = Console.ReadLine();
        Console.Write("Enter Car Model: ");
        string model = Console.ReadLine();
        Console.Write("Enter Car Rent per Day: ");
        string rent = Console.ReadLine();

        string carRecord = id + "," + model + "," + rent;
        File.AppendAllText(filePath, carRecord + "\n");
        Console.WriteLine("Car added successfully!");
    }

    static void ViewCars()
    {
        if (!File.Exists(filePath) || File.ReadAllText(filePath).Trim() == "")
        {
            Console.WriteLine("No records found.");
            return;
        }

        Console.WriteLine("\nCar Records:");
        string[] records = File.ReadAllLines(filePath);
        foreach (string record in records)
        {
            string[] details = record.Split(',');
            Console.WriteLine($"ID: {details[0]}, Model: {details[1]}, Rent: {details[2]}");
        }
    }

    static void UpdateCar()
    {
        Console.Write("Enter Car ID to Update: ");
        string updateId = Console.ReadLine();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No records found.");
            return;
        }
        string[] records = File.ReadAllLines(filePath);
        bool found = false;
        List<string> updatedRecords = new List<string>();

        foreach (string record in records)
        {
            string[] details = record.Split(',');
            if (details[0] == updateId)
            {
                found = true;
                Console.Write("Enter New Model: ");
                details[1] = Console.ReadLine();
                Console.Write("Enter New Rent: ");
                details[2] = Console.ReadLine();
                updatedRecords.Add(string.Join(",", details));
                Console.WriteLine("Car updated successfully!");
            }
            else
            {
                updatedRecords.Add(record);
            }
        }

        if (!found)
        {
            Console.WriteLine("Error: Car ID not found! Please enter a valid ID.");
        }
        else
        {
            File.WriteAllLines(filePath, updatedRecords);
        }
    }

    static void DeleteCar()
    {
        Console.Write("Enter Car ID to Delete: ");
        string deleteId = Console.ReadLine();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No records found.");
            return;
        }
        string[] records = File.ReadAllLines(filePath);
        bool found = false;
        List<string> updatedRecords = new List<string>();

        foreach (string record in records)
        {
            string[] details = record.Split(',');
            if (details[0] == deleteId)
            {
                found = true;
                Console.WriteLine("Car deleted successfully!");
                continue;
            }
            updatedRecords.Add(record);
        }

        if (!found)
        {
            Console.WriteLine("Car ID not found!");
        }
        else
        {
            File.WriteAllLines(filePath, updatedRecords);
        }
    }
}
