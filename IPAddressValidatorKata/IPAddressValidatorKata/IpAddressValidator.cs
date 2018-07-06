using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace IPAddressValidatorKata
{
    public class IpAddressValidator
    {

        public bool ValidateIpV4Address(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            if (input.EndsWith("0") || input.EndsWith("255")) return false;
            var separator = input.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

            return separator.Length >= 4;
        }   
    }
}