using Threax.AspNetCore.Halcyon.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace Threax.GitServer.Client {

public class RoleAssignmentsResult 
{
    private HalEndpointClient client;

    public RoleAssignmentsResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private RoleAssignments strongData = default(RoleAssignments);
    public RoleAssignments Data 
    {
        get
        {
            if(this.strongData == default(RoleAssignments))
            {
                this.strongData = this.client.GetData<RoleAssignments>();  
            }
            return this.strongData;
        }
    }

    public async Task<RoleAssignmentsResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new RoleAssignmentsResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<RoleAssignmentsResult> SetUser(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("SetUser", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanSetUser 
    {
        get 
        {
            return this.client.HasLink("SetUser");
        }
    }

    public HalLink LinkForSetUser 
    {
        get 
        {
            return this.client.GetLink("SetUser");
        }
    }

    public async Task<HalEndpointDoc> GetSetUserDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("SetUser", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasSetUserDocs() {
        return this.client.HasLinkDoc("SetUser");
    }

    public async Task<RoleAssignmentsResult> Update(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task Delete() 
    {
        var result = await this.client.LoadLink("Delete");
    }

    public bool CanDelete 
    {
        get 
        {
            return this.client.HasLink("Delete");
        }
    }

    public HalLink LinkForDelete 
    {
        get 
        {
            return this.client.GetLink("Delete");
        }
    }
}

public class AuthorizedKeyResult 
{
    private HalEndpointClient client;

    public AuthorizedKeyResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private AuthorizedKey strongData = default(AuthorizedKey);
    public AuthorizedKey Data 
    {
        get
        {
            if(this.strongData == default(AuthorizedKey))
            {
                this.strongData = this.client.GetData<AuthorizedKey>();  
            }
            return this.strongData;
        }
    }

    public async Task<AuthorizedKeyResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new AuthorizedKeyResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<AuthorizedKeyResult> Update(AuthorizedKeyInput data) 
    {
        var result = await this.client.LoadLinkWithData("Update", data);
        return new AuthorizedKeyResult(result);

    }

    public bool CanUpdate 
    {
        get 
        {
            return this.client.HasLink("Update");
        }
    }

    public HalLink LinkForUpdate 
    {
        get 
        {
            return this.client.GetLink("Update");
        }
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task Delete() 
    {
        var result = await this.client.LoadLink("Delete");
    }

    public bool CanDelete 
    {
        get 
        {
            return this.client.HasLink("Delete");
        }
    }

    public HalLink LinkForDelete 
    {
        get 
        {
            return this.client.GetLink("Delete");
        }
    }
}

public class AuthorizedKeyCollectionResult 
{
    private HalEndpointClient client;

    public AuthorizedKeyCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private AuthorizedKeyCollection strongData = default(AuthorizedKeyCollection);
    public AuthorizedKeyCollection Data 
    {
        get
        {
            if(this.strongData == default(AuthorizedKeyCollection))
            {
                this.strongData = this.client.GetData<AuthorizedKeyCollection>();  
            }
            return this.strongData;
        }
    }

    private List<AuthorizedKeyResult> itemsStrong = null;
    public List<AuthorizedKeyResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<AuthorizedKeyResult>(clients.Select(i => new AuthorizedKeyResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<AuthorizedKeyCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new AuthorizedKeyCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<AuthorizedKeyResult> Add(AuthorizedKeyInput data) 
    {
        var result = await this.client.LoadLinkWithData("Add", data);
        return new AuthorizedKeyResult(result);

    }

    public bool CanAdd 
    {
        get 
        {
            return this.client.HasLink("Add");
        }
    }

    public HalLink LinkForAdd 
    {
        get 
        {
            return this.client.GetLink("Add");
        }
    }

    public async Task<HalEndpointDoc> GetAddDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Add", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddDocs() {
        return this.client.HasLinkDoc("Add");
    }

    public async Task<AuthorizedKeyCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new AuthorizedKeyCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<AuthorizedKeyCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new AuthorizedKeyCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<AuthorizedKeyCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new AuthorizedKeyCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<AuthorizedKeyCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new AuthorizedKeyCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class EntryPointInjector 
{
    private string url;
    private IHttpClientFactory fetcher;
    private Task<EntryPointResult> instanceTask = default(Task<EntryPointResult>);

    public EntryPointInjector(string url, IHttpClientFactory fetcher)
    {
        this.url = url;
        this.fetcher = fetcher;
    }

    public Task<EntryPointResult> Load()
    {
        if (this.instanceTask == default(Task<EntryPointResult>))
        {
            this.instanceTask = EntryPointResult.Load(this.url, this.fetcher);
        }
        return this.instanceTask;
    }
}

public class EntryPointResult 
{
    private HalEndpointClient client;

    public static async Task<EntryPointResult> Load(string url, IHttpClientFactory fetcher)
    {
        var result = await HalEndpointClient.Load(new HalLink(url, "GET"), fetcher);
        return new EntryPointResult(result);
    }

    public EntryPointResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private EntryPoint strongData = default(EntryPoint);
    public EntryPoint Data 
    {
        get
        {
            if(this.strongData == default(EntryPoint))
            {
                this.strongData = this.client.GetData<EntryPoint>();  
            }
            return this.strongData;
        }
    }

    public async Task<AuthorizedKeyCollectionResult> ListAuthorizedKeys(AuthorizedKeyQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListAuthorizedKeys", data);
        return new AuthorizedKeyCollectionResult(result);

    }

    public bool CanListAuthorizedKeys 
    {
        get 
        {
            return this.client.HasLink("ListAuthorizedKeys");
        }
    }

    public HalLink LinkForListAuthorizedKeys 
    {
        get 
        {
            return this.client.GetLink("ListAuthorizedKeys");
        }
    }

    public async Task<HalEndpointDoc> GetListAuthorizedKeysDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListAuthorizedKeys", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListAuthorizedKeysDocs() {
        return this.client.HasLinkDoc("ListAuthorizedKeys");
    }

    public async Task<AuthorizedKeyResult> AddAuthorizedKey(AuthorizedKeyInput data) 
    {
        var result = await this.client.LoadLinkWithData("AddAuthorizedKey", data);
        return new AuthorizedKeyResult(result);

    }

    public bool CanAddAuthorizedKey 
    {
        get 
        {
            return this.client.HasLink("AddAuthorizedKey");
        }
    }

    public HalLink LinkForAddAuthorizedKey 
    {
        get 
        {
            return this.client.GetLink("AddAuthorizedKey");
        }
    }

    public async Task<HalEndpointDoc> GetAddAuthorizedKeyDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("AddAuthorizedKey", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddAuthorizedKeyDocs() {
        return this.client.HasLinkDoc("AddAuthorizedKey");
    }

    public async Task<EntryPointResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new EntryPointResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<RoleAssignmentsResult> GetUser() 
    {
        var result = await this.client.LoadLink("GetUser");
        return new RoleAssignmentsResult(result);

    }

    public bool CanGetUser 
    {
        get 
        {
            return this.client.HasLink("GetUser");
        }
    }

    public HalLink LinkForGetUser 
    {
        get 
        {
            return this.client.GetLink("GetUser");
        }
    }

    public async Task<HalEndpointDoc> GetGetUserDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("GetUser", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetUserDocs() {
        return this.client.HasLinkDoc("GetUser");
    }

    public async Task<UserCollectionResult> ListUsers(RolesQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListUsers", data);
        return new UserCollectionResult(result);

    }

    public bool CanListUsers 
    {
        get 
        {
            return this.client.HasLink("ListUsers");
        }
    }

    public HalLink LinkForListUsers 
    {
        get 
        {
            return this.client.GetLink("ListUsers");
        }
    }

    public async Task<HalEndpointDoc> GetListUsersDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListUsers", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListUsersDocs() {
        return this.client.HasLinkDoc("ListUsers");
    }

    public async Task<RoleAssignmentsResult> SetUser(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("SetUser", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanSetUser 
    {
        get 
        {
            return this.client.HasLink("SetUser");
        }
    }

    public HalLink LinkForSetUser 
    {
        get 
        {
            return this.client.GetLink("SetUser");
        }
    }

    public async Task<HalEndpointDoc> GetSetUserDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("SetUser", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasSetUserDocs() {
        return this.client.HasLinkDoc("SetUser");
    }

    public async Task<UserSearchCollectionResult> ListAppUsers(UserSearchQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListAppUsers", data);
        return new UserSearchCollectionResult(result);

    }

    public bool CanListAppUsers 
    {
        get 
        {
            return this.client.HasLink("ListAppUsers");
        }
    }

    public HalLink LinkForListAppUsers 
    {
        get 
        {
            return this.client.GetLink("ListAppUsers");
        }
    }

    public async Task<HalEndpointDoc> GetListAppUsersDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListAppUsers", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListAppUsersDocs() {
        return this.client.HasLinkDoc("ListAppUsers");
    }

    public async Task<GitRepoCollectionResult> ListGitRepos(GitRepoQuery data) 
    {
        var result = await this.client.LoadLinkWithData("ListGitRepos", data);
        return new GitRepoCollectionResult(result);

    }

    public bool CanListGitRepos 
    {
        get 
        {
            return this.client.HasLink("ListGitRepos");
        }
    }

    public HalLink LinkForListGitRepos 
    {
        get 
        {
            return this.client.GetLink("ListGitRepos");
        }
    }

    public async Task<HalEndpointDoc> GetListGitReposDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("ListGitRepos", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListGitReposDocs() {
        return this.client.HasLinkDoc("ListGitRepos");
    }

    public async Task<GitRepoResult> AddGitRepo(GitRepoInput data) 
    {
        var result = await this.client.LoadLinkWithData("AddGitRepo", data);
        return new GitRepoResult(result);

    }

    public bool CanAddGitRepo 
    {
        get 
        {
            return this.client.HasLink("AddGitRepo");
        }
    }

    public HalLink LinkForAddGitRepo 
    {
        get 
        {
            return this.client.GetLink("AddGitRepo");
        }
    }

    public async Task<HalEndpointDoc> GetAddGitRepoDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("AddGitRepo", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddGitRepoDocs() {
        return this.client.HasLinkDoc("AddGitRepo");
    }
}

public class GitRepoResult 
{
    private HalEndpointClient client;

    public GitRepoResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private GitRepo strongData = default(GitRepo);
    public GitRepo Data 
    {
        get
        {
            if(this.strongData == default(GitRepo))
            {
                this.strongData = this.client.GetData<GitRepo>();  
            }
            return this.strongData;
        }
    }

    public async Task<GitRepoResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new GitRepoResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task Delete() 
    {
        var result = await this.client.LoadLink("Delete");
    }

    public bool CanDelete 
    {
        get 
        {
            return this.client.HasLink("Delete");
        }
    }

    public HalLink LinkForDelete 
    {
        get 
        {
            return this.client.GetLink("Delete");
        }
    }
}

public class GitRepoCollectionResult 
{
    private HalEndpointClient client;

    public GitRepoCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private GitRepoCollection strongData = default(GitRepoCollection);
    public GitRepoCollection Data 
    {
        get
        {
            if(this.strongData == default(GitRepoCollection))
            {
                this.strongData = this.client.GetData<GitRepoCollection>();  
            }
            return this.strongData;
        }
    }

    private List<GitRepoResult> itemsStrong = null;
    public List<GitRepoResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<GitRepoResult>(clients.Select(i => new GitRepoResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<GitRepoCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new GitRepoCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<GitRepoResult> Add(GitRepoInput data) 
    {
        var result = await this.client.LoadLinkWithData("Add", data);
        return new GitRepoResult(result);

    }

    public bool CanAdd 
    {
        get 
        {
            return this.client.HasLink("Add");
        }
    }

    public HalLink LinkForAdd 
    {
        get 
        {
            return this.client.GetLink("Add");
        }
    }

    public async Task<HalEndpointDoc> GetAddDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Add", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddDocs() {
        return this.client.HasLinkDoc("Add");
    }

    public async Task<GitRepoCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new GitRepoCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<GitRepoCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new GitRepoCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<GitRepoCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new GitRepoCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<GitRepoCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new GitRepoCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class UserCollectionResult 
{
    private HalEndpointClient client;

    public UserCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private UserCollection strongData = default(UserCollection);
    public UserCollection Data 
    {
        get
        {
            if(this.strongData == default(UserCollection))
            {
                this.strongData = this.client.GetData<UserCollection>();  
            }
            return this.strongData;
        }
    }

    private List<RoleAssignmentsResult> itemsStrong = null;
    public List<RoleAssignmentsResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<RoleAssignmentsResult>(clients.Select(i => new RoleAssignmentsResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<UserCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new UserCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<HalEndpointDoc> GetUpdateDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Update", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasUpdateDocs() {
        return this.client.HasLinkDoc("Update");
    }

    public async Task<RoleAssignmentsResult> Add(RoleAssignments data) 
    {
        var result = await this.client.LoadLinkWithData("Add", data);
        return new RoleAssignmentsResult(result);

    }

    public bool CanAdd 
    {
        get 
        {
            return this.client.HasLink("Add");
        }
    }

    public HalLink LinkForAdd 
    {
        get 
        {
            return this.client.GetLink("Add");
        }
    }

    public async Task<HalEndpointDoc> GetAddDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Add", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasAddDocs() {
        return this.client.HasLinkDoc("Add");
    }

    public async Task<UserCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new UserCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<UserCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new UserCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<UserCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new UserCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<UserCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new UserCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}

public class UserSearchResult 
{
    private HalEndpointClient client;

    public UserSearchResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private UserSearch strongData = default(UserSearch);
    public UserSearch Data 
    {
        get
        {
            if(this.strongData == default(UserSearch))
            {
                this.strongData = this.client.GetData<UserSearch>();  
            }
            return this.strongData;
        }
    }

    public async Task<UserSearchResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new UserSearchResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }
}

public class UserSearchCollectionResult 
{
    private HalEndpointClient client;

    public UserSearchCollectionResult(HalEndpointClient client) 
    {
        this.client = client;
    }

    private UserSearchCollection strongData = default(UserSearchCollection);
    public UserSearchCollection Data 
    {
        get
        {
            if(this.strongData == default(UserSearchCollection))
            {
                this.strongData = this.client.GetData<UserSearchCollection>();  
            }
            return this.strongData;
        }
    }

    private List<UserSearchResult> itemsStrong = null;
    public List<UserSearchResult> Items
    {
        get
        {
            if (this.itemsStrong == null) 
            {
                var embeds = this.client.GetEmbed("values");
                var clients = embeds.GetAllClients();
                this.itemsStrong = new List<UserSearchResult>(clients.Select(i => new UserSearchResult(i)));
            }
            return this.itemsStrong;
        }
    }

    public async Task<UserSearchCollectionResult> Refresh() 
    {
        var result = await this.client.LoadLink("self");
        return new UserSearchCollectionResult(result);

    }

    public bool CanRefresh 
    {
        get 
        {
            return this.client.HasLink("self");
        }
    }

    public HalLink LinkForRefresh 
    {
        get 
        {
            return this.client.GetLink("self");
        }
    }

    public async Task<HalEndpointDoc> GetRefreshDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("self", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasRefreshDocs() {
        return this.client.HasLinkDoc("self");
    }

    public async Task<HalEndpointDoc> GetGetDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("Get", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasGetDocs() {
        return this.client.HasLinkDoc("Get");
    }

    public async Task<HalEndpointDoc> GetListDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("List", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasListDocs() {
        return this.client.HasLinkDoc("List");
    }

    public async Task<UserSearchCollectionResult> Next() 
    {
        var result = await this.client.LoadLink("next");
        return new UserSearchCollectionResult(result);

    }

    public bool CanNext 
    {
        get 
        {
            return this.client.HasLink("next");
        }
    }

    public HalLink LinkForNext 
    {
        get 
        {
            return this.client.GetLink("next");
        }
    }

    public async Task<HalEndpointDoc> GetNextDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("next", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasNextDocs() {
        return this.client.HasLinkDoc("next");
    }

    public async Task<UserSearchCollectionResult> Previous() 
    {
        var result = await this.client.LoadLink("previous");
        return new UserSearchCollectionResult(result);

    }

    public bool CanPrevious 
    {
        get 
        {
            return this.client.HasLink("previous");
        }
    }

    public HalLink LinkForPrevious 
    {
        get 
        {
            return this.client.GetLink("previous");
        }
    }

    public async Task<HalEndpointDoc> GetPreviousDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("previous", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasPreviousDocs() {
        return this.client.HasLinkDoc("previous");
    }

    public async Task<UserSearchCollectionResult> First() 
    {
        var result = await this.client.LoadLink("first");
        return new UserSearchCollectionResult(result);

    }

    public bool CanFirst 
    {
        get 
        {
            return this.client.HasLink("first");
        }
    }

    public HalLink LinkForFirst 
    {
        get 
        {
            return this.client.GetLink("first");
        }
    }

    public async Task<HalEndpointDoc> GetFirstDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("first", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasFirstDocs() {
        return this.client.HasLinkDoc("first");
    }

    public async Task<UserSearchCollectionResult> Last() 
    {
        var result = await this.client.LoadLink("last");
        return new UserSearchCollectionResult(result);

    }

    public bool CanLast 
    {
        get 
        {
            return this.client.HasLink("last");
        }
    }

    public HalLink LinkForLast 
    {
        get 
        {
            return this.client.GetLink("last");
        }
    }

    public async Task<HalEndpointDoc> GetLastDocs(HalEndpointDocQuery query = null) 
    {
        var result = await this.client.LoadLinkDoc("last", query);
        return result.GetData<HalEndpointDoc>();
    }

    public bool HasLastDocs() {
        return this.client.HasLinkDoc("last");
    }
}
}
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v1.0.1.0 (Newtonsoft.Json v12.0.0.0) (http://NJsonSchema.org)
// </auto-generated>
//----------------------

namespace Threax.GitServer.Client
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class RoleAssignments 
    {
        [Newtonsoft.Json.JsonProperty("editGitRepos", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditGitRepos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("deleteGitRepos", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool DeleteGitRepos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editAuthorizedKeys", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditAuthorizedKeys { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editRoles", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditRoles { get; set; }
    
        [Newtonsoft.Json.JsonProperty("superAdmin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool SuperAdmin { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static RoleAssignments FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RoleAssignments>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AuthorizedKey 
    {
        [Newtonsoft.Json.JsonProperty("authorizedKeyId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid AuthorizedKeyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PublicKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Enabled { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static AuthorizedKey FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizedKey>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AuthorizedKeyInput 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("publicKey", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PublicKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enabled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Enabled { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static AuthorizedKeyInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizedKeyInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AuthorizedKeyCollection 
    {
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>Lookup a authorizedKey by id.</summary>
        [Newtonsoft.Json.JsonProperty("authorizedKeyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? AuthorizedKeyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static AuthorizedKeyCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizedKeyCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class AuthorizedKeyQuery 
    {
        /// <summary>Lookup a authorizedKey by id.</summary>
        [Newtonsoft.Json.JsonProperty("authorizedKeyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? AuthorizedKeyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static AuthorizedKeyQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthorizedKeyQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class EntryPoint 
    {
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static EntryPoint FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<EntryPoint>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class RolesQuery 
    {
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<System.Guid> UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editRoles", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditRoles { get; set; }
    
        [Newtonsoft.Json.JsonProperty("superAdmin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool SuperAdmin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static RolesQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RolesQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class UserCollection 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public List<System.Guid> UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editRoles", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditRoles { get; set; }
    
        [Newtonsoft.Json.JsonProperty("superAdmin", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool SuperAdmin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class UserSearchQuery 
    {
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserSearchQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserSearchQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class UserSearchCollection 
    {
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid? UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserSearchCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserSearchCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class GitRepoQuery 
    {
        /// <summary>Lookup a gitRepo by id.</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static GitRepoQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GitRepoQuery>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class GitRepoCollection 
    {
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        /// <summary>Lookup a gitRepo by id.</summary>
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static GitRepoCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GitRepoCollection>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class GitRepoInput 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static GitRepoInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GitRepoInput>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class GitRepo 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("clonePath", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClonePath { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Created { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTime Modified { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static GitRepo FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GitRepo>(data);
        }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "1.0.1.0 (Newtonsoft.Json v12.0.0.0)")]
    public partial class UserSearch 
    {
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        public string ToJson() 
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
        public static UserSearch FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserSearch>(data);
        }
    
    }
}
