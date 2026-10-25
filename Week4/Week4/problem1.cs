/*using System;
using System.Collections.Generic;
using System.Text;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            int choice = 0;

            do
            {
                Console.WriteLine("\nDriver Program Menu:");
                Console.WriteLine("1. Add Ship");
                Console.WriteLine("2. View Ship Position");
                Console.WriteLine("3. View Ship Serial Number");
                Console.WriteLine("4. Change Ship Position");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter Ship Number: ");
                    string shipNum = Console.ReadLine();

                    Console.WriteLine("Enter Ship Latitude:");
                    Console.Write("Enter Latitude's Degree: ");
                    int latDeg = int.Parse(Console.ReadLine());
                    Console.Write("Enter Latitude's Minute: ");
                    float latMin = float.Parse(Console.ReadLine());
                    Console.Write("Enter Latitude's Direction: ");
                    char latDir = char.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Ship Longitude:");
                    Console.Write("Enter Longitude's Degree: ");
                    int lonDeg = int.Parse(Console.ReadLine());
                    Console.Write("Enter Longitude's Minute: ");
                    float lonMin = float.Parse(Console.ReadLine());
                    Console.Write("Enter Longitude's Direction: ");
                    char lonDir = char.Parse(Console.ReadLine());

                    Angle lat = new Angle(latDeg, latMin, latDir);
                    Angle lon = new Angle(lonDeg, lonMin, lonDir);

                    ships.Add(new Ship(shipNum, lat, lon));
                }
                else if (choice == 2)
                {
                    Console.Write("Enter Ship Serial Number to find its position: ");
                    string searchNumPos = Console.ReadLine();

                    Ship foundShipPos = null;
                    foreach (Ship s in ships)
                    {
                        if (s.serialNumber == searchNumPos)
                        {
                            foundShipPos = s;
                            break;
                        }
                    }

                    if (foundShipPos != null)
                    {
                        foundShipPos.PrintPosition();
                    }
                    else
                    {
                        Console.WriteLine("Ship not found.");
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Ship Serial Number: ");
                    string searchNumSer = Console.ReadLine();

                    Ship foundShipSer = null;
                    foreach (Ship s in ships)
                    {
                        if (s.serialNumber == searchNumSer)
                        {
                            foundShipSer = s;
                            break;
                        }
                    }

                    if (foundShipSer != null)
                    {
                        foundShipSer.PrintSerialNumber();
                    }
                    else
                    {
                        Console.WriteLine("Ship not found.");
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Ship's serial number whose position you want to change: ");
                    string changeNum = Console.ReadLine();

                    Ship foundShipChange = null;
                    foreach (Ship s in ships)
                    {
                        if (s.serialNumber == changeNum)
                        {
                            foundShipChange = s;
                            break;
                        }
                    }

                    if (foundShipChange != null)
                    {
                        Console.WriteLine("Enter Ship Latitude:");
                        Console.Write("Enter Latitude's Degree: ");
                        int newLatDeg = int.Parse(Console.ReadLine());
                        Console.Write("Enter Latitude's Minute: ");
                        float newLatMin = float.Parse(Console.ReadLine());
                        Console.Write("Enter Latitude's Direction: ");
                        char newLatDir = char.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Ship Longitude:");
                        Console.Write("Enter Longitude's Degree: ");
                        int newLonDeg = int.Parse(Console.ReadLine());
                        Console.Write("Enter Longitude's Minute: ");
                        float newLonMin = float.Parse(Console.ReadLine());
                        Console.Write("Enter Longitude's Direction: ");
                        char newLonDir = char.Parse(Console.ReadLine());

                        foundShipChange.UpdatePosition(new Angle(newLatDeg, newLatMin, newLatDir), new Angle(newLonDeg, newLonMin, newLonDir));
                        Console.WriteLine("Position updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Ship not found.");
                    }
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Exiting program.");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }

            } while (choice != 5);
        }
    }
}

public class Angle
{
    public int degrees;
    public float minutes;
    public char direction;


    public Angle(int deg, float min, char dir)
    {
        degrees = deg;
        minutes = min;
        direction = dir;
    }


    public void SetAngle(int deg, float min, char dir)
    {
        degrees = deg;
        minutes = min;
        direction = dir;
    }

    public string GetAngleString()
    {
        char degreeSymbol = '\u00b0';
        return $"{degrees}{degreeSymbol}{minutes}' {direction}";
    }
}


public class Ship
{
    public string serialNumber;
    public Angle latitude;
    public Angle longitude;

    public Ship(string serialNum, Angle lat, Angle lon)
    {
        serialNumber = serialNum;
        latitude = lat;
        longitude = lon;
    }


    public void UpdatePosition(Angle newLat, Angle newLon)
    {
        latitude = newLat;
        longitude = newLon;
    }

    public void PrintPosition()
    {
        Console.WriteLine($"Ship is at {latitude.GetAngleString()} and {longitude.GetAngleString()}");
    }

    public void PrintSerialNumber()
    {
        Console.WriteLine($"Ship's serial number is {serialNumber}");
    }
}*/
