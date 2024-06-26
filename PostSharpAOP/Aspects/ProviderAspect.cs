﻿using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace PostSharpAOPSample.Aspects
{

    // https://www.postsharp.net/blog/category/Tutorial?page=3

    [PSerializable]
    public class ProviderAspect : MethodLevelAspect, IAspectProvider
    {
        public IEnumerable<AspectInstance> ProvideAspects(object targetElement)
        {
            MemberInfo nfo = (MemberInfo)targetElement;


            if (nfo.Name.EndsWith("VAT"))
            {
                yield return new AspectInstance(targetElement, new CustomLoggerAspect());
            }

        }
    }
}
