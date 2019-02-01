using System;
using System.Reflection;

namespace Cede_Dotnet_MedicalAppointment_Api.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}