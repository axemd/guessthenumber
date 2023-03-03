int readNumber(int i = 1, int t = 100)
{
    var toAnalyze = Console.ReadLine();
    bool isNumber = int.TryParse(toAnalyze, out _);
    if (!isNumber) return new Random().Next(i, t);
    return int.Parse(toAnalyze);
}
string ans = "o";
while (ans == "o")
{
    Random rdm = new Random();
    Console.WriteLine("Information : Toute valeur incorrecte mènera au remplacement par une valeur aléatoire comprise entre 1 et 100, ou l'intervalle s'il est défini.");
    Console.WriteLine("Merci de définir un intervalle pour votre nombre.");
    Console.WriteLine("Choisissez le nombre de départ (ou d'arrivée).");
    int s = readNumber();
    Console.WriteLine("Choisissez l'autre limite de l'intervalle.");
    int e = readNumber();
    bool intervalDirection = s < e;
    int r;
    while(s == e || s < 0 || e < 0)
    {
        Console.WriteLine("Cet intervalle est refusé, merci de renseigner deux valeurs différentes et supérieures ou égales à 0.");
        Console.WriteLine("Choisissez le nombre de départ (ou d'arrivée).");
        s = readNumber();
        Console.WriteLine("Choisissez l'autre limite de l'intervalle.");
        e = readNumber();
        intervalDirection = s < e;
    }

    Console.WriteLine("Ok. C'est parti");
    if (intervalDirection)
    {
        Console.WriteLine("Intervalle : [" + s.ToString() + ", " + e.ToString() + "]");
        r = rdm.Next(s, e);
    }
    else
    {
        Console.WriteLine("Intervalle : [" + e.ToString() + ", " + s.ToString() + "]");
        r = rdm.Next(e, s);
    }
    int n = readNumber((intervalDirection) ? s : e, (intervalDirection) ? e : s);
    while (n != r)
    {
        if (n == -1) // Voir solution
        {
            Console.WriteLine(r);
        }
        if (n < r)
        {
            Console.WriteLine(((intervalDirection) ? n < s : n < e) ? "Nombre en dessous de l'intervalle" : "Plus haut");
        }
        else
        {
            Console.WriteLine(((intervalDirection) ? n > e : n > s) ? "Nombre au dessus de l'intervalle" : "Plus bas");
        }
        n = readNumber((intervalDirection) ? s : e, (intervalDirection) ? e : s);
    }
    Console.WriteLine("Félicitations ! Voulez-vous rejouer ? (o/n)");
    ans = Console.ReadLine();
}