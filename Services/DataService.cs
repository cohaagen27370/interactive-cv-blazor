using System.Net.Http.Json;
using System.Runtime.ConstrainedExecution;
using interactiveCvBlazor.Components.Certificate;
using interactiveCvBlazor.Components.Experience;
using interactiveCvBlazor.Components.Skill;
using interactiveCvBlazor.Services.Dtos;

namespace interactiveCvBlazor.Services;

public class DataService(HttpClient httpClient) : IDataService
{
    public async Task<List<CertificateModel>> GetCertificatesAsync()
    {
        try
        {
            var certificates = await httpClient.GetFromJsonAsync<CertificateDto>("trainings.data.json");
            
            return certificates is null ? [] : certificates.Trainings;
        }
        catch (HttpRequestException ex)
        {
            // Gérer les erreurs HTTP (par exemple, fichier non trouvé, problème de réseau)
            Console.WriteLine($"Erreur HTTP lors de la récupération des formations : {ex.Message}");
            return []; // Retourne une liste vide en cas d'erreur
        }
        catch (System.Text.Json.JsonException ex)
        {
            // Gérer les erreurs de désérialisation JSON (par exemple, format JSON invalide)
            Console.WriteLine($"Erreur de désérialisation JSON : {ex.Message}");
            return [];
        }
        catch (Exception ex)
        {
            // Gérer les autres exceptions imprévues
            Console.WriteLine($"Une erreur inattendue est survenue : {ex.Message}");
            return [];
        }
    }
    
    public async Task<List<ExperienceModel>> GetExperiencesAsync()
    {
        try
        {
            var experiences = await httpClient.GetFromJsonAsync<ExperienceDto>("experiences.data.json");
            
            return experiences is null ? [] : experiences.Experiences;
        }
        catch (HttpRequestException ex)
        {
            // Gérer les erreurs HTTP (par exemple, fichier non trouvé, problème de réseau)
            Console.WriteLine($"Erreur HTTP lors de la récupération des expériences : {ex.Message}");
            return []; // Retourne une liste vide en cas d'erreur
        }
        catch (System.Text.Json.JsonException ex)
        {
            // Gérer les erreurs de désérialisation JSON (par exemple, format JSON invalide)
            Console.WriteLine($"Erreur de désérialisation JSON : {ex.Message}");
            return [];
        }
        catch (Exception ex)
        {
            // Gérer les autres exceptions imprévues
            Console.WriteLine($"Une erreur inattendue est survenue : {ex.Message}");
            return [];
        }
    }
    
    public async Task<List<SkillModel>> GetSkillsAsync()
    {
        try
        {
            var skills = await httpClient.GetFromJsonAsync<SkillDto>("skills.data.json");
            
            return skills is null ? [] : skills.Skills;
        }
        catch (HttpRequestException ex)
        {
            // Gérer les erreurs HTTP (par exemple, fichier non trouvé, problème de réseau)
            Console.WriteLine($"Erreur HTTP lors de la récupération des expériences : {ex.Message}");
            return []; // Retourne une liste vide en cas d'erreur
        }
        catch (System.Text.Json.JsonException ex)
        {
            // Gérer les erreurs de désérialisation JSON (par exemple, format JSON invalide)
            Console.WriteLine($"Erreur de désérialisation JSON : {ex.Message}");
            return [];
        }
        catch (Exception ex)
        {
            // Gérer les autres exceptions imprévues
            Console.WriteLine($"Une erreur inattendue est survenue : {ex.Message}");
            return [];
        }
    }

    public async Task<PresentationDto?> GetPresentationAsync()
    {
        try
        {
            return await httpClient.GetFromJsonAsync<PresentationDto>("presentation.data.json");
            
        }
        catch (HttpRequestException ex)
        {
            // Gérer les erreurs HTTP (par exemple, fichier non trouvé, problème de réseau)
            Console.WriteLine($"Erreur HTTP lors de la récupération des expériences : {ex.Message}");
            return null; // Retourne une liste vide en cas d'erreur
        }
        catch (System.Text.Json.JsonException ex)
        {
            // Gérer les erreurs de désérialisation JSON (par exemple, format JSON invalide)
            Console.WriteLine($"Erreur de désérialisation JSON : {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            // Gérer les autres exceptions imprévues
            Console.WriteLine($"Une erreur inattendue est survenue : {ex.Message}");
            return null;
        }
    }

}