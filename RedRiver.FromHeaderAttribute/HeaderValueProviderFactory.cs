//
// FromHeaderAttribute - enables model binding and validation of HTTP headers in Web API
//
// Copyright (c) Red River Software Ltd.  All rights reserved.
//
// This source code is made available under the terms of the MIT General License.
//
using System.Web.Http.Controllers;
using System.Web.Http.ValueProviders;

namespace RedRiver.FromHeaderAttribute
{
    /// <summary>
    /// Factory used by the Web API framework to get an instance of our value provider.
    /// </summary>
    public class HeaderValueProviderFactory : ValueProviderFactory
    {
        /// <summary>
        /// Captures the headers collection from the request and returns a new instance of
        /// HeaderValueProvider.
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        public override IValueProvider GetValueProvider(HttpActionContext actionContext)
        {
            return new HeaderValueProvider(actionContext.Request.Headers);
        }
    }
}