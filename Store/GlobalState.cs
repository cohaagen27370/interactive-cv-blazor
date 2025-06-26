using interactiveCvBlazor.Components.Certificate;
using interactiveCvBlazor.Components.Experience;
using interactiveCvBlazor.Components.Skill;
using interactiveCvBlazor.Services;
using interactiveCvBlazor.Services.Dtos;
using TG.Blazor.IndexedDB;

namespace interactiveCvBlazor.Store;

public class GlobalState(DataService dataService, IndexedDBManager dbManager)
{
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();

    private string _page { get; set; } = string.Empty;
    private PresentationDto? _presentation { get; set; }
    
    private List<CertificateModel> _certificates = [];    
    
    private List<ExperienceModel> _experiences = [];
    private List<SkillModel> _skills = [];
    private HowToDto? _howTo { get; set; }    
    private VersionDto? _version { get; set; }

    private readonly DataService dataService = dataService;
    
    
    private static bool _isInitialized = false;
    
    
    public async Task Init()
    {
        _page = "";

        if (_isInitialized)
            return;

        _isInitialized = true;

        this._version = await dataService.GetVersionAsync();
        var localVersions = await dbManager.GetRecords<VersionDto>("version");

        if (localVersions != null && localVersions.Count != 0)
        {
            if (this._version != null && this._version.Version != localVersions[0].Version)
            {
                localVersions[0].Id = this._version.Id;
                
                await dbManager.ClearStore("presentation");
                await dbManager.ClearStore("howtos");
                await dbManager.ClearStore("experiences");
                await dbManager.ClearStore("skills");
                await dbManager.ClearStore("trainings");
                await dbManager.UpdateRecord(new StoreRecord<VersionDto> { Data = localVersions[0]});
            }
        }
        else
        {
            await dbManager.AddRecord(new StoreRecord<VersionDto> { Storename = "version", Data = this._version!});
        }

        List<PresentationDto>? localPresentation = await dbManager.GetRecords<PresentationDto>("presentation");
        if (localPresentation == null || localPresentation.Count == 0)
        {
            this._presentation = await dataService.GetPresentationAsync();
            await dbManager.AddRecord(new StoreRecord<PresentationDto> { Storename = "presentation" , Data = this._presentation!});
        }
        else
        {
            this._presentation = localPresentation[0];       
        }
        
        var localHowTo = await dbManager.GetRecords<HowToDto>("howtos");
        if (localHowTo == null || localHowTo.Count == 0)
        {
            this._howTo = await dataService.GetHowToAsync();
            await dbManager.AddRecord(new StoreRecord<HowToDto> { Storename = "howtos" , Data = this._howTo!});
        }
        else
        {
            this._howTo = localHowTo[0];       
        }        

        List<CertificateModel>? localCertificates = await dbManager.GetRecords<CertificateModel>("trainings");
        if (localCertificates == null || localCertificates.Count == 0)
        {
            this._certificates = await dataService.GetCertificatesAsync();
            await dbManager.AddRecord(new StoreRecord<List<CertificateModel>> { Storename = "trainings" ,  Data = this._certificates});
        }
        else
        {
            this._certificates = localCertificates;       
        }
        
        List<ExperienceModel>? localExperiences = await dbManager.GetRecords<ExperienceModel>("experiences");
        if (localExperiences == null  || localExperiences.Count == 0)
        {
            this._experiences = await dataService.GetExperiencesAsync();
            await dbManager.AddRecord(new StoreRecord<List<ExperienceModel>> { Storename = "experiences" ,  Data = this._experiences});
        }
        else
        {
            this._experiences = localExperiences;       
        }
        
        List<SkillModel>? localSkills = await dbManager.GetRecords<SkillModel>("skills");
        if (localSkills == null || localSkills.Count == 0)
        {
            this._skills = await dataService.GetSkillsAsync();
            await dbManager.AddRecord(new StoreRecord<List<SkillModel>> { Storename = "skills" ,  Data = this._skills});
        }
        else
        {
            this._skills = localSkills;       
        }        
        
    }
    
    public List<ExperienceModel> Experiences
    {
        get => _experiences;
        private set
        {
            if (_experiences == value) return;
            _experiences = value;
            NotifyStateChanged();
        }
    }
    public List<SkillModel> Skills
    {
        get => _skills;
        private set
        {
            if (_skills == value) return;
            _skills = value;
            NotifyStateChanged();
        }
    }

    
    public List<CertificateModel> Certificates
    {
        get => _certificates;
        private set
        {
            if (_certificates == value) return;
            _certificates = value;
            NotifyStateChanged();
        }
    }
    
    public PresentationDto? Presentation
    {
        get => _presentation;
        private set
        {
            if (_presentation == value) return;
            _presentation = value;
            NotifyStateChanged();
        }
    }
    
    public HowToDto? HowTo
    {
        get => _howTo;
        private set
        {
            if (_howTo == value) return;
            _howTo = value;
            NotifyStateChanged();
        }
    }
    
    public string Page
    {
        get => _page;
        private set
        {
            if (_page == value) return;
            _page = value;
            NotifyStateChanged();
        }
    }
    
    public void SetPage(string page)
    {
        _page = page;
    }

}