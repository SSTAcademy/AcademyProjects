﻿using System.Security.Cryptography.X509Certificates;

namespace MyFirstApi.Linq
{
    public class Database
    {
        public Database()
        {

            Students = new List<Student>()
            {
                new()
                {
                    Name = "Dilara",
                    Surname = "karaduman",
                    Height = 155,
                    Number = 100,
                    Color = "Red",
                    Rank = 78
                },
                new()
                {
                    Name = "Ayse",
                    Surname = "Kaya",
                    Height = 138,
                    Number = 101,
                    Color = "Red",
                    Rank = 88
                },
                new()
                {
                    Name = "Erdem",
                    Surname = "Altun",
                    Height = 188,
                    Number = 102,
                    Color = "Blue",
                    Rank = 87
                },
                new()
                {
                    Name = "Elif",
                    Surname = "Kotan",
                    Height = 157,
                    Number = 103,
                    Color = "Blue",
                    Rank = 92
                },
                new()
                {
                    Name = "Gamze",
                    Surname = "Gizem",
                    Height = 148,
                    Number = 104,
                    Color = "Green",
                    Rank = 93
                },
                new()
                {
                    Name = "Hasan",
                    Surname = "Kakıcı",
                    Height = 178,
                    Number = 105,
                    Color = "White",
                    Rank = 95
                },
                new()
                {
                    Name = "Hakan",
                    Surname = "Mert",
                    Height = 188,
                    Number = 106,
                    Color = "Black",
                    Rank = 78
                },
                new()
                {
                    Name = "Pelin",
                    Surname = "Kaya",
                    Height = 158,
                    Number = 107,
                    Color = "Blue",
                    Rank = 100
                },
                new()
                {
                    Name = "Selin",
                    Surname = "Bozak",
                    Height = 158,
                    Number = 108,
                    Color = "Pink",
                    Rank = 100
                }
            };
        
    }
        public List<Student> Students { get; set; }
    }
}
