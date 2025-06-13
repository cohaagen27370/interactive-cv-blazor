using interactiveCvBlazor.Components.Certificate;
using interactiveCvBlazor.Components.Experience;
using interactiveCvBlazor.Components.Skill;
using interactiveCvBlazor.Services.Dtos;

namespace interactiveCvBlazor.Services;

public interface IDataService
{
    Task<List<CertificateModel>> GetCertificatesAsync();
    Task<List<ExperienceModel>> GetExperiencesAsync();
    Task<List<SkillModel>> GetSkillsAsync();
    Task<PresentationDto?> GetPresentationAsync();
}