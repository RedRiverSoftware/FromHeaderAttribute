//
// FromHeaderAttribute - enables model binding and validation of HTTP headers in Web API
//
// Copyright (c) Red River Software Ltd.  All rights reserved.
//
// This source code is made available under the terms of the MIT General License.
//
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http.ValueProviders;

namespace RedRiver.FromHeaderAttribute
{
    /// <summary>
    /// Model binding value provider which sources values from HTTP request headers.  By default,
    /// transforms model member names into HTTP header names by adding dashes before uppercase characters
    /// other than the first (e.g. XHelloWorld becomes X-Hello-World).  Flattens all members in the
    /// target model type.
    /// </summary>
    public class HeaderValueProvider : IValueProvider
    {
        private readonly HttpRequestHeaders _headers;

        /// <summary>
        /// Creates a new instance of the HeaderValueProvider class
        /// </summary>
        /// <param name="headers"></param>
        public HeaderValueProvider(HttpRequestHeaders headers)
        {
            _headers = headers;
        }

        /// <summary>
        /// Indicates whether a given prefix can be handled by this value provider.  Always returns true
        /// since prefixes are made irrelevant by this provider's logic
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public bool ContainsPrefix(string prefix)
        {
            // all prefixes are flattened - all members and sub-members of the model type considered equally
            return true;
        }

        /// <summary>
        /// Attempts to retrieve the value for a particular model binding key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ValueProviderResult GetValue(string key)
        {
            IEnumerable<string> values;

            // keys come in with dot notation - take only the very last component to flatten
            var propName = RemovePrefixes(key);

            // convert this member name into a HTTP header name
            var headerName = MakeHeaderName(propName);

            if (!_headers.TryGetValues(headerName, out values))
            {
                return null;
            }
            var data = string.Join(",", values.ToArray());
            return new ValueProviderResult(values, data, CultureInfo.InvariantCulture);
        }

        private static string RemovePrefixes(string key)
        {
            var lastDot = key.LastIndexOf('.');
            if (lastDot == -1) return key;

            return key.Substring(lastDot + 1);
        }

        private static string MakeHeaderName(string key)
        {
            var headerBuilder = new StringBuilder();

            for (int i = 0; i < key.Length; i++)
            {
                // prefix any uppercase characters other than the first with a dash
                if (char.IsUpper(key[i]) && i > 0)
                {
                    headerBuilder.Append('-');
                }
                headerBuilder.Append(key[i]);
            }

            return headerBuilder.ToString();
        }
    }
}