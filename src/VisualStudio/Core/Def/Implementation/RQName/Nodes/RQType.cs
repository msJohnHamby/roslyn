// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using Microsoft.VisualStudio.LanguageServices.Implementation.RQName.SimpleTree;

namespace Microsoft.VisualStudio.LanguageServices.Implementation.RQName.Nodes
{
    internal abstract class RQType
    {
        public static readonly RQType ObjectType = new RQConstructedType(
            new RQUnconstructedType(new[] { "System" }, new[] { new RQUnconstructedTypeInfo("Object", 0) }),
            Array.Empty<RQType>());

        public abstract SimpleTreeNode ToSimpleTree();
    }
}
