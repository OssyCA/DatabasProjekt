using MySchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasProjekt
{
    internal class ManageSchool
    {
        public static void MainMenu()
        {
            Menu menu = new(["Lägg till i skolan", "Hämta info", "Exit"], "Main Menu");

            while (true)
            {
                switch (menu.MenuRun())
                {
                    case 0:
                        AddToSchool addToSchool = new();
                        addToSchool.AddMenu();
                        break;
                    case 1:
                        ReadFromSchoolDb readFromSchoolDb = new();
                        readFromSchoolDb.ReadMenu();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;

                }

            }
        }
    }
}
