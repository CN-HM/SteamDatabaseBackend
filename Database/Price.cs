﻿/*
 * Copyright (c) 2013-present, SteamDB. All rights reserved.
 * Use of this source code is governed by a BSD-style license that can be
 * found in the LICENSE file.
 */
namespace SteamDatabaseBackend
{
    internal class Price
    {
        public string Country { get; set; }
        public uint PriceFinal { get; set; }
        public uint PriceDiscount { get; set; }

        public string Format()
        {
            var cents = PriceFinal / 100.0;
            var discount = PriceDiscount > 0 ? string.Format(" at -{0}%", PriceDiscount) : string.Empty;

            return Country switch
            {
                "uk" => string.Format("£{0:0.00}{1}", cents, discount),
                "us" => string.Format("${0:0.00}{1}", cents, discount),
                "eu" => string.Format("{0:0.00}€{1}", cents, discount).Replace('.', ',').Replace(",00", ",--"),
                _ => string.Format("{1}: {0}", cents, Country),
            };
        }
    }
}
