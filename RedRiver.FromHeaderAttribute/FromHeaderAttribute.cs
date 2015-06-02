//
// FromHeaderAttribute - enables model binding and validation of HTTP headers in Web API
//
// Copyright (c) Red River Software Ltd.  All rights reserved.
//
// This source code is made available under the terms of the MIT General License.
//
using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace RedRiver.FromHeaderAttribute
{
    /// <summary>
    /// An attribute that specifies an action parameter comes from the HTTP headers of the incoming request
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
    public class FromHeaderAttribute : ParameterBindingAttribute
    {
        /// <summary>
        /// Gets the binding for this HTTP header parameter
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            if (parameter == null) throw new ArgumentNullException("parameter");

            // combine the model binder for this configuration with our value provider
            var httpConfig = parameter.Configuration;
            var binder = new ModelBinderAttribute().GetModelBinder(httpConfig, parameter.ParameterType);

            return new ModelBinderParameterBinding(parameter, binder, new ValueProviderFactory[] { new HeaderValueProviderFactory() });
        }
    }
}
