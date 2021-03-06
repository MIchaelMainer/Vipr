﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Vipr.Core;
using Vipr.Core.CodeModel;

namespace Vipr.Writer.CSharp.Lite
{
    public class CSharpWriter : IOdcmWriter, IConfigurable
    {
        public CSharpWriter()
        {
        }

        public IEnumerable<TextFile> GenerateProxy(OdcmModel model)
        {
            var csProject = new CSharpProject(model);

            var codeGenerator = new SourceCodeGenerator(model.ServiceType);

            return codeGenerator.Generate(csProject);
        }

        public void SetConfigurationProvider(IConfigurationProvider configurationProvider)
        {
            ConfigurationService.Initialize(configurationProvider);
        }
    }
}
