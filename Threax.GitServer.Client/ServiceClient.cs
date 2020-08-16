using Threax.AspNetCore.Halcyon.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;

namespace Threax.GitServer.Client
{

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
                if (this.strongData == default(RoleAssignments))
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

        public async Task<HalEndpointDoc> GetRefreshDocs()
        {
            var result = await this.client.LoadLinkDoc("self");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasRefreshDocs()
        {
            return this.client.HasLinkDoc("self");
        }

        public async Task<RoleAssignmentsResult> SetUser(RoleAssignments data)
        {
            var result = await this.client.LoadLinkWithBody("SetUser", data);
            return new RoleAssignmentsResult(result);

        }

        public bool CanSetUser
        {
            get
            {
                return this.client.HasLink("SetUser");
            }
        }

        public async Task<HalEndpointDoc> GetSetUserDocs()
        {
            var result = await this.client.LoadLinkDoc("SetUser");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasSetUserDocs()
        {
            return this.client.HasLinkDoc("SetUser");
        }

        public async Task DeleteUser()
        {
            var result = await this.client.LoadLink("DeleteUser");
        }

        public bool CanDeleteUser
        {
            get
            {
                return this.client.HasLink("DeleteUser");
            }
        }
    }

    public class EntryPointInjector
    {
        private string url;
        private IHttpClientFactory fetcher;
        private EntryPointResult instance = default(EntryPointResult);

        public EntryPointInjector(string url, IHttpClientFactory fetcher)
        {
            this.url = url;
            this.fetcher = fetcher;
        }

        public async Task<EntryPointResult> Load()
        {
            if (this.instance == default(EntryPointResult))
            {
                this.instance = await EntryPointResult.Load(this.url, this.fetcher);
            }
            return this.instance;
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
                if (this.strongData == default(EntryPoint))
                {
                    this.strongData = this.client.GetData<EntryPoint>();
                }
                return this.strongData;
            }
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

        public async Task<HalEndpointDoc> GetRefreshDocs()
        {
            var result = await this.client.LoadLinkDoc("self");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasRefreshDocs()
        {
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

        public async Task<HalEndpointDoc> GetGetUserDocs()
        {
            var result = await this.client.LoadLinkDoc("GetUser");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasGetUserDocs()
        {
            return this.client.HasLinkDoc("GetUser");
        }

        public async Task<UserCollectionResult> ListUsers(RolesQuery query)
        {
            var result = await this.client.LoadLinkWithQuery("ListUsers", query);
            return new UserCollectionResult(result);

        }

        public bool CanListUsers
        {
            get
            {
                return this.client.HasLink("ListUsers");
            }
        }

        public async Task<HalEndpointDoc> GetListUsersDocs()
        {
            var result = await this.client.LoadLinkDoc("ListUsers");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasListUsersDocs()
        {
            return this.client.HasLinkDoc("ListUsers");
        }

        public async Task<RoleAssignmentsResult> SetUser(RoleAssignments data)
        {
            var result = await this.client.LoadLinkWithBody("SetUser", data);
            return new RoleAssignmentsResult(result);

        }

        public bool CanSetUser
        {
            get
            {
                return this.client.HasLink("SetUser");
            }
        }

        public async Task<HalEndpointDoc> GetSetUserDocs()
        {
            var result = await this.client.LoadLinkDoc("SetUser");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasSetUserDocs()
        {
            return this.client.HasLinkDoc("SetUser");
        }

        public async Task<ValueCollectionResult> ListValues(PagedCollectionQuery query)
        {
            var result = await this.client.LoadLinkWithQuery("ListValues", query);
            return new ValueCollectionResult(result);

        }

        public bool CanListValues
        {
            get
            {
                return this.client.HasLink("ListValues");
            }
        }

        public async Task<HalEndpointDoc> GetListValuesDocs()
        {
            var result = await this.client.LoadLinkDoc("ListValues");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasListValuesDocs()
        {
            return this.client.HasLinkDoc("ListValues");
        }

        public async Task<ValueResult> AddValue(ValueInput data)
        {
            var result = await this.client.LoadLinkWithBody("AddValue", data);
            return new ValueResult(result);

        }

        public bool CanAddValue
        {
            get
            {
                return this.client.HasLink("AddValue");
            }
        }

        public async Task<HalEndpointDoc> GetAddValueDocs()
        {
            var result = await this.client.LoadLinkDoc("AddValue");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasAddValueDocs()
        {
            return this.client.HasLinkDoc("AddValue");
        }
    }

    public class ValueResult
    {
        private HalEndpointClient client;

        public ValueResult(HalEndpointClient client)
        {
            this.client = client;
        }

        private Value strongData = default(Value);
        public Value Data
        {
            get
            {
                if (this.strongData == default(Value))
                {
                    this.strongData = this.client.GetData<Value>();
                }
                return this.strongData;
            }
        }

        public async Task<ValueResult> Refresh()
        {
            var result = await this.client.LoadLink("self");
            return new ValueResult(result);

        }

        public bool CanRefresh
        {
            get
            {
                return this.client.HasLink("self");
            }
        }

        public async Task<HalEndpointDoc> GetRefreshDocs()
        {
            var result = await this.client.LoadLinkDoc("self");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasRefreshDocs()
        {
            return this.client.HasLinkDoc("self");
        }

        public async Task<ValueResult> Update(ValueInput data)
        {
            var result = await this.client.LoadLinkWithBody("Update", data);
            return new ValueResult(result);

        }

        public bool CanUpdate
        {
            get
            {
                return this.client.HasLink("Update");
            }
        }

        public async Task<HalEndpointDoc> GetUpdateDocs()
        {
            var result = await this.client.LoadLinkDoc("Update");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasUpdateDocs()
        {
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
    }

    public class ValueCollectionResult
    {
        private HalEndpointClient client;

        public ValueCollectionResult(HalEndpointClient client)
        {
            this.client = client;
        }

        private ValueCollection strongData = default(ValueCollection);
        public ValueCollection Data
        {
            get
            {
                if (this.strongData == default(ValueCollection))
                {
                    this.strongData = this.client.GetData<ValueCollection>();
                }
                return this.strongData;
            }
        }

        private List<ValueResult> strongItems = null;
        public List<ValueResult> Items
        {
            get
            {
                if (this.strongItems == null)
                {
                    var embeds = this.client.GetEmbed("values");
                    var clients = embeds.GetAllClients();
                    this.strongItems = new List<ValueResult>(clients.Select(i => new ValueResult(i)));
                }
                return this.strongItems;
            }
        }

        public async Task<ValueCollectionResult> Refresh()
        {
            var result = await this.client.LoadLink("self");
            return new ValueCollectionResult(result);

        }

        public bool CanRefresh
        {
            get
            {
                return this.client.HasLink("self");
            }
        }

        public async Task<HalEndpointDoc> GetRefreshDocs()
        {
            var result = await this.client.LoadLinkDoc("self");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasRefreshDocs()
        {
            return this.client.HasLinkDoc("self");
        }

        public async Task<HalEndpointDoc> GetListDocs()
        {
            var result = await this.client.LoadLinkDoc("List");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasListDocs()
        {
            return this.client.HasLinkDoc("List");
        }

        public async Task<ValueResult> Add(ValueInput data)
        {
            var result = await this.client.LoadLinkWithBody("Add", data);
            return new ValueResult(result);

        }

        public bool CanAdd
        {
            get
            {
                return this.client.HasLink("Add");
            }
        }

        public async Task<HalEndpointDoc> GetAddDocs()
        {
            var result = await this.client.LoadLinkDoc("Add");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasAddDocs()
        {
            return this.client.HasLinkDoc("Add");
        }

        public async Task<ValueCollectionResult> Next()
        {
            var result = await this.client.LoadLink("next");
            return new ValueCollectionResult(result);

        }

        public bool CanNext
        {
            get
            {
                return this.client.HasLink("next");
            }
        }

        public async Task<HalEndpointDoc> GetNextDocs()
        {
            var result = await this.client.LoadLinkDoc("next");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasNextDocs()
        {
            return this.client.HasLinkDoc("next");
        }

        public async Task<ValueCollectionResult> Previous()
        {
            var result = await this.client.LoadLink("previous");
            return new ValueCollectionResult(result);

        }

        public bool CanPrevious
        {
            get
            {
                return this.client.HasLink("previous");
            }
        }

        public async Task<HalEndpointDoc> GetPreviousDocs()
        {
            var result = await this.client.LoadLinkDoc("previous");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasPreviousDocs()
        {
            return this.client.HasLinkDoc("previous");
        }

        public async Task<ValueCollectionResult> First()
        {
            var result = await this.client.LoadLink("first");
            return new ValueCollectionResult(result);

        }

        public bool CanFirst
        {
            get
            {
                return this.client.HasLink("first");
            }
        }

        public async Task<HalEndpointDoc> GetFirstDocs()
        {
            var result = await this.client.LoadLinkDoc("first");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasFirstDocs()
        {
            return this.client.HasLinkDoc("first");
        }

        public async Task<ValueCollectionResult> Last()
        {
            var result = await this.client.LoadLink("last");
            return new ValueCollectionResult(result);

        }

        public bool CanLast
        {
            get
            {
                return this.client.HasLink("last");
            }
        }

        public async Task<HalEndpointDoc> GetLastDocs()
        {
            var result = await this.client.LoadLinkDoc("last");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasLastDocs()
        {
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
                if (this.strongData == default(UserCollection))
                {
                    this.strongData = this.client.GetData<UserCollection>();
                }
                return this.strongData;
            }
        }

        private List<RoleAssignmentsResult> strongItems = null;
        public List<RoleAssignmentsResult> Items
        {
            get
            {
                if (this.strongItems == null)
                {
                    var embeds = this.client.GetEmbed("values");
                    var clients = embeds.GetAllClients();
                    this.strongItems = new List<RoleAssignmentsResult>(clients.Select(i => new RoleAssignmentsResult(i)));
                }
                return this.strongItems;
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

        public async Task<HalEndpointDoc> GetRefreshDocs()
        {
            var result = await this.client.LoadLinkDoc("self");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasRefreshDocs()
        {
            return this.client.HasLinkDoc("self");
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

        public async Task<HalEndpointDoc> GetNextDocs()
        {
            var result = await this.client.LoadLinkDoc("next");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasNextDocs()
        {
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

        public async Task<HalEndpointDoc> GetPreviousDocs()
        {
            var result = await this.client.LoadLinkDoc("previous");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasPreviousDocs()
        {
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

        public async Task<HalEndpointDoc> GetFirstDocs()
        {
            var result = await this.client.LoadLinkDoc("first");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasFirstDocs()
        {
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

        public async Task<HalEndpointDoc> GetLastDocs()
        {
            var result = await this.client.LoadLinkDoc("last");
            return result.GetData<HalEndpointDoc>();
        }

        public bool HasLastDocs()
        {
            return this.client.HasLinkDoc("last");
        }
    }
}
//----------------------
// <auto-generated>
//     Generated using the NJsonSchema v9.4.5.0 (http://NJsonSchema.org)
// </auto-generated>
//----------------------

namespace Threax.GitServer.Client
{
#pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.5.0")]
    public partial class RoleAssignments
    {
        [Newtonsoft.Json.JsonProperty("editValues", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EditValues { get; set; }

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

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.5.0")]
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

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.5.0")]
    public partial class RolesQuery
    {
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.ObjectModel.ObservableCollection<System.Guid> UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }

        /// <summary>The limit of the number of items to return.</summary>
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

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.5.0")]
    public partial class UserCollection
    {
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static UserCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<UserCollection>(data);
        }
    }

    /// <summary>Default implementation of ICollectionQuery.</summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.5.0")]
    public partial class PagedCollectionQuery
    {
        /// <summary>The number of pages (item number = Offset * Limit) into the collection to query.</summary>
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }

        /// <summary>The limit of the number of items to return.</summary>
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static PagedCollectionQuery FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<PagedCollectionQuery>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.5.0")]
    public partial class ValueCollection
    {
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("total", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Total { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ValueCollection FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ValueCollection>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.5.0")]
    public partial class ValueInput
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static ValueInput FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ValueInput>(data);
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.4.5.0")]
    public partial class Value
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("valueId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid ValueId { get; set; }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        public static Value FromJson(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Value>(data);
        }
    }
}

