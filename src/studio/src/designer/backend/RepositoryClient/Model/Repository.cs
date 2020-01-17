/*
 * Gitea API.
 *
 * This documentation describes the Gitea API.
 *
 * OpenAPI spec version: 1.1.1
 *
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SwaggerDateConverter = Altinn.Studio.Designer.RepositoryClient.Client.SwaggerDateConverter;

namespace Altinn.Studio.Designer.RepositoryClient.Model
{
    /// <summary>
    /// Repository represents a repository
    /// </summary>
    [DataContract]
    public partial class Repository : IEquatable<Repository>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository" /> class.
        /// </summary>
        /// <param name="CloneUrl">CloneUrl.</param>
        /// <param name="CreatedAt">CreatedAt.</param>
        /// <param name="DefaultBranch">DefaultBranch.</param>
        /// <param name="Description">Description.</param>
        /// <param name="Empty">Empty.</param>
        /// <param name="Fork">Fork.</param>
        /// <param name="ForksCount">ForksCount.</param>
        /// <param name="FullName">FullName.</param>
        /// <param name="HtmlUrl">HtmlUrl.</param>
        /// <param name="Id">Id.</param>
        /// <param name="Mirror">Mirror.</param>
        /// <param name="Name">Name.</param>
        /// <param name="OpenIssuesCount">OpenIssuesCount.</param>
        /// <param name="Owner">Owner.</param>
        /// <param name="Parent">Parent.</param>
        /// <param name="Permissions">Permissions.</param>
        /// <param name="_Private">_Private.</param>
        /// <param name="Size">Size.</param>
        /// <param name="SshUrl">SshUrl.</param>
        /// <param name="StarsCount">StarsCount.</param>
        /// <param name="UpdatedAt">UpdatedAt.</param>
        /// <param name="WatchersCount">WatchersCount.</param>
        /// <param name="Website">Website.</param>
        public Repository(string CloneUrl = default(string), DateTime? CreatedAt = default(DateTime?), string DefaultBranch = default(string), string Description = default(string), bool? Empty = default(bool?), bool? Fork = default(bool?), long? ForksCount = default(long?), string FullName = default(string), string HtmlUrl = default(string), long? Id = default(long?), bool? Mirror = default(bool?), string Name = default(string), long? OpenIssuesCount = default(long?), User Owner = default(User), Repository Parent = default(Repository), Permission Permissions = default(Permission), bool? _Private = default(bool?), long? Size = default(long?), string SshUrl = default(string), long? StarsCount = default(long?), DateTime? UpdatedAt = default(DateTime?), long? WatchersCount = default(long?), string Website = default(string))
        {
            this.CloneUrl = CloneUrl;
            this.CreatedAt = CreatedAt;
            this.DefaultBranch = DefaultBranch;
            this.Description = Description;
            this.Empty = Empty;
            this.Fork = Fork;
            this.ForksCount = ForksCount;
            this.FullName = FullName;
            this.HtmlUrl = HtmlUrl;
            this.Id = Id;
            this.Mirror = Mirror;
            this.Name = Name;
            this.OpenIssuesCount = OpenIssuesCount;
            this.Owner = Owner;
            this.Parent = Parent;
            this.Permissions = Permissions;
            this.IsPrivate = _Private;
            this.Size = Size;
            this.SshUrl = SshUrl;
            this.StarsCount = StarsCount;
            this.UpdatedAt = UpdatedAt;
            this.WatchersCount = WatchersCount;
            this.Website = Website;
        }

        /// <summary>
        /// Gets or Sets CloneUrl
        /// </summary>
        [JsonProperty("clone_url")]
        public string CloneUrl { get; set; }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or Sets DefaultBranch
        /// </summary>
        [JsonProperty("default_branch")]
        public string DefaultBranch { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Empty
        /// </summary>
        [JsonProperty("empty")]
        public bool? Empty { get; set; }

        /// <summary>
        /// Gets or Sets Fork
        /// </summary>
        [JsonProperty("fork")]
        public bool? Fork { get; set; }

        /// <summary>
        /// Gets or Sets ForksCount
        /// </summary>
        [JsonProperty("forks_count")]
        public long? ForksCount { get; set; }

        /// <summary>
        /// Gets or Sets FullName
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or Sets HtmlUrl
        /// </summary>
        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [JsonProperty("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Mirror
        /// </summary>
        [JsonProperty("mirror")]
        public bool? Mirror { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets OpenIssuesCount
        /// </summary>
        [JsonProperty("open_issues_count")]
        public long? OpenIssuesCount { get; set; }

        /// <summary>
        /// Gets or Sets Owner
        /// </summary>
        [JsonProperty("owner")]
        public User Owner { get; set; }

        /// <summary>
        /// Gets or Sets Parent
        /// </summary>
        [JsonProperty("parent")]
        public Repository Parent { get; set; }

        /// <summary>
        /// Gets or Sets Permissions
        /// </summary>
        [JsonProperty("permissions")]
        public Permission Permissions { get; set; }

        /// <summary>
        /// Gets or Sets _Private
        /// </summary>
        [JsonProperty("private")]
        public bool? IsPrivate { get; set; }

        /// <summary>
        /// Gets or Sets Size
        /// </summary>
        [JsonProperty("size")]
        public long? Size { get; set; }

        /// <summary>
        /// Gets or Sets SshUrl
        /// </summary>
        [JsonProperty("ssh_url")]
        public string SshUrl { get; set; }

        /// <summary>
        /// Gets or Sets StarsCount
        /// </summary>
        [JsonProperty("stars_count")]
        public long? StarsCount { get; set; }

        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or Sets WatchersCount
        /// </summary>
        [JsonProperty("watchers_count")]
        public long? WatchersCount { get; set; }

        /// <summary>
        /// Gets or Sets Website
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets whether the repository is cloned to local
        /// </summary>
        [JsonProperty("is_cloned_to_local")]
        public bool IsClonedToLocal { get; set; }

        /// <summary>
        /// Gets or sets the repository created status
        /// </summary>
        [JsonProperty]
        public HttpStatusCode RepositoryCreatedStatus { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Repository {\n");
            sb.Append("  CloneUrl: ").Append(CloneUrl).Append("\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  DefaultBranch: ").Append(DefaultBranch).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Empty: ").Append(Empty).Append("\n");
            sb.Append("  Fork: ").Append(Fork).Append("\n");
            sb.Append("  ForksCount: ").Append(ForksCount).Append("\n");
            sb.Append("  FullName: ").Append(FullName).Append("\n");
            sb.Append("  HtmlUrl: ").Append(HtmlUrl).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Mirror: ").Append(Mirror).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OpenIssuesCount: ").Append(OpenIssuesCount).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
            sb.Append("  Permissions: ").Append(Permissions).Append("\n");
            sb.Append("  _Private: ").Append(IsPrivate).Append("\n");
            sb.Append("  Size: ").Append(Size).Append("\n");
            sb.Append("  SshUrl: ").Append(SshUrl).Append("\n");
            sb.Append("  StarsCount: ").Append(StarsCount).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  WatchersCount: ").Append(WatchersCount).Append("\n");
            sb.Append("  Website: ").Append(Website).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Repository);
        }

        /// <summary>
        /// Returns true if Repository instances are equal
        /// </summary>
        /// <param name="input">Instance of Repository to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Repository input)
        {
            if (input == null)
            {
                return false;
            }

            return
                (
                    this.CloneUrl == input.CloneUrl ||
                    (this.CloneUrl != null &&
                    this.CloneUrl.Equals(input.CloneUrl))) &&
                (
                    this.CreatedAt == input.CreatedAt ||
                    (this.CreatedAt != null &&
                    this.CreatedAt.Equals(input.CreatedAt))) &&
                (
                    this.DefaultBranch == input.DefaultBranch ||
                    (this.DefaultBranch != null &&
                    this.DefaultBranch.Equals(input.DefaultBranch))) &&
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))) &&
                (
                    this.Empty == input.Empty ||
                    (this.Empty != null &&
                    this.Empty.Equals(input.Empty))) &&
                (
                    this.Fork == input.Fork ||
                    (this.Fork != null &&
                    this.Fork.Equals(input.Fork))) &&
                (
                    this.ForksCount == input.ForksCount ||
                    (this.ForksCount != null &&
                    this.ForksCount.Equals(input.ForksCount))) &&
                (
                    this.FullName == input.FullName ||
                    (this.FullName != null &&
                    this.FullName.Equals(input.FullName))) &&
                (
                    this.HtmlUrl == input.HtmlUrl ||
                    (this.HtmlUrl != null &&
                    this.HtmlUrl.Equals(input.HtmlUrl))) &&
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))) &&
                (
                    this.Mirror == input.Mirror ||
                    (this.Mirror != null &&
                    this.Mirror.Equals(input.Mirror))) &&
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))) &&
                (
                    this.OpenIssuesCount == input.OpenIssuesCount ||
                    (this.OpenIssuesCount != null &&
                    this.OpenIssuesCount.Equals(input.OpenIssuesCount))) &&
                (
                    this.Owner == input.Owner ||
                    (this.Owner != null &&
                    this.Owner.Equals(input.Owner))) &&
                (
                    this.Parent == input.Parent ||
                    (this.Parent != null &&
                    this.Parent.Equals(input.Parent))) &&
                (
                    this.Permissions == input.Permissions ||
                    (this.Permissions != null &&
                    this.Permissions.Equals(input.Permissions))) &&
                (
                    this.IsPrivate == input.IsPrivate ||
                    (this.IsPrivate != null &&
                    this.IsPrivate.Equals(input.IsPrivate))) &&
                (
                    this.Size == input.Size ||
                    (this.Size != null &&
                    this.Size.Equals(input.Size))) &&
                (
                    this.SshUrl == input.SshUrl ||
                    (this.SshUrl != null &&
                    this.SshUrl.Equals(input.SshUrl))) &&
                (
                    this.StarsCount == input.StarsCount ||
                    (this.StarsCount != null &&
                    this.StarsCount.Equals(input.StarsCount))) &&
                (
                    this.UpdatedAt == input.UpdatedAt ||
                    (this.UpdatedAt != null &&
                    this.UpdatedAt.Equals(input.UpdatedAt))) &&
                (
                    this.WatchersCount == input.WatchersCount ||
                    (this.WatchersCount != null &&
                    this.WatchersCount.Equals(input.WatchersCount))) &&
                (
                    this.Website == input.Website ||
                    (this.Website != null &&
                    this.Website.Equals(input.Website)));
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // Overflow is fine, just wrap
            unchecked
            {
                int hashCode = 41;
                if (this.CloneUrl != null)
                {
                    hashCode = (hashCode * 59) + this.CloneUrl.GetHashCode();
                }

                if (this.CreatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedAt.GetHashCode();
                }

                if (this.DefaultBranch != null)
                {
                    hashCode = (hashCode * 59) + this.DefaultBranch.GetHashCode();
                }

                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }

                if (this.Empty != null)
                {
                    hashCode = (hashCode * 59) + this.Empty.GetHashCode();
                }

                if (this.Fork != null)
                {
                    hashCode = (hashCode * 59) + this.Fork.GetHashCode();
                }

                if (this.ForksCount != null)
                {
                    hashCode = (hashCode * 59) + this.ForksCount.GetHashCode();
                }

                if (this.FullName != null)
                {
                    hashCode = (hashCode * 59) + this.FullName.GetHashCode();
                }

                if (this.HtmlUrl != null)
                {
                    hashCode = (hashCode * 59) + this.HtmlUrl.GetHashCode();
                }

                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }

                if (this.Mirror != null)
                {
                    hashCode = (hashCode * 59) + this.Mirror.GetHashCode();
                }

                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }

                if (this.OpenIssuesCount != null)
                {
                    hashCode = (hashCode * 59) + this.OpenIssuesCount.GetHashCode();
                }

                if (this.Owner != null)
                {
                    hashCode = (hashCode * 59) + this.Owner.GetHashCode();
                }

                if (this.Parent != null)
                {
                    hashCode = (hashCode * 59) + this.Parent.GetHashCode();
                }

                if (this.Permissions != null)
                {
                    hashCode = (hashCode * 59) + this.Permissions.GetHashCode();
                }

                if (this.IsPrivate != null)
                {
                    hashCode = (hashCode * 59) + this.IsPrivate.GetHashCode();
                }

                if (this.Size != null)
                {
                    hashCode = (hashCode * 59) + this.Size.GetHashCode();
                }

                if (this.SshUrl != null)
                {
                    hashCode = (hashCode * 59) + this.SshUrl.GetHashCode();
                }

                if (this.StarsCount != null)
                {
                    hashCode = (hashCode * 59) + this.StarsCount.GetHashCode();
                }

                if (this.UpdatedAt != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedAt.GetHashCode();
                }

                if (this.WatchersCount != null)
                {
                    hashCode = (hashCode * 59) + this.WatchersCount.GetHashCode();
                }

                if (this.Website != null)
                {
                    hashCode = (hashCode * 59) + this.Website.GetHashCode();
                }

                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
