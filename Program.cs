using System;
using System.Text.RegularExpressions;

public class CartaoCredito
{
    public static string IdentificarBandeira(string numero)
    {
        string num = numero.Replace(" ", "").Replace("-", "");

        // American Express
        if (Regex.IsMatch(num, @"^(34|37)\d{13}$"))
            return "American Express";

        // Diners Club - Carte Blanche
        if (Regex.IsMatch(num, @"^30[0-5]\d{11}$"))
            return "Diners Club - Carte Blanche";

        // Diners Club - International
        if (Regex.IsMatch(num, @"^36\d{12}$"))
            return "Diners Club - International";

        // MasterCard
        if (Regex.IsMatch(num, @"^(5[1-5]\d{14})$") ||
            (num.Length == 16 && int.TryParse(num.Substring(0, 6), out int iin) && iin >= 222100 && iin <= 272099))
            return "MasterCard";

        // Visa Electron
        if (Regex.IsMatch(num, @"^(4026|417500|4508|4844|4913|4917)\d{10,12}$") && num.Length == 16)
            return "Visa Electron";

        // Visa
        if (Regex.IsMatch(num, @"^4\d{12}(\d{3})?(\d{3})?$") && (num.Length == 13 || num.Length == 16 || num.Length == 19))
            return "Visa";

        // Elo (exemplo de alguns BINs)
        if (Regex.IsMatch(num, @"^(4011(78|79)|431274|438935|451416|457393|504175|5067\d{2}|5090\d{2}|627780|636297|636368|650\d{3}|6516\d{2}|6550\d{2})\d{10,12}$"))
            return "Elo";

        // Hipercard
        if (Regex.IsMatch(num, @"^(38\d{17}|60\d{14})$"))
            return "Hipercard";

        // JCB
        if (Regex.IsMatch(num, @"^35\d{14}$"))
            return "JCB";

        // Discover
        if (Regex.IsMatch(num, @"^(6011\d{12}|65\d{14}|64[4-9]\d{13}|622(12[6-9]|1[3-9]\d|2\d{2}|9[0-1]\d|92[0-5])\d{10})$"))
            return "Discover";

        // Aura
        if (Regex.IsMatch(num, @"^50\d{14,17}$"))
            return "Aura";

        // EnRoute
        if (Regex.IsMatch(num, @"^(2014|2149)\d{11}$"))
            return "EnRoute";

        // Voyager
        if (Regex.IsMatch(num, @"^8699\d{11,12}$"))
            return "Voyager";

        // UnionPay
        if (Regex.IsMatch(num, @"^62\d{14,17}$"))
            return "UnionPay";

        return "Bandeira desconhecida";
    }

    // Exemplo de uso:
    public static void Main()
    {
        string[] exemplos = {
            "86990 6454 63618 2", 
           
        };

        foreach (var cartao in exemplos)
        {
            Console.WriteLine($"{cartao} => {IdentificarBandeira(cartao)}");
        }
    }
}
