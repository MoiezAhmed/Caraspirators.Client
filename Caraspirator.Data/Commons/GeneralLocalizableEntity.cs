﻿
using Caraspirator.Data.Entities.DTO;
using System.Globalization;

namespace Caraspirator.Data.Commons;

public class GeneralLocalizableEntity
{

    public string Localize(string textAr, string textEN)
    {
        CultureInfo CultureInfo = Thread.CurrentThread.CurrentCulture;
        if (CultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            return textAr;
        return textEN;
    }
}
