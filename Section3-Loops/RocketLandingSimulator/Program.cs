// See https://aka.ms/new-console-template for more information

string rocket = "     |  \r\n     |  \r\n    /^\\ \r\n    | | \r\n    | | \r\n    | | \r\n    | | \r\n   ]|U|[\r\n    === ";

string landingPad = "  _______";

for (int counter = 0; counter < 9; counter++)
{
    landingPad = "\r\n" + landingPad;
}

for (int counter = 10; counter > 0; counter--)
{
    Console.Clear();
    Console.WriteLine(rocket);
    Console.WriteLine(landingPad);
    landingPad = landingPad.Substring(2);
    rocket = "\r\n" + rocket;
    Thread.Sleep(1000);
}