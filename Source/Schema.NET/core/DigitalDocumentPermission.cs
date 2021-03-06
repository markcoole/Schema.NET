﻿namespace Schema.NET
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// A permission for a particular person or group to access a particular file.
    /// </summary>
    public partial interface IDigitalDocumentPermission : IIntangible
    {
        /// <summary>
        /// The person, organization, contact point, or audience that has been granted this permission.
        /// </summary>
        Values<IAudience, IContactPoint, IOrganization, IPerson> Grantee { get; set; }

        /// <summary>
        /// The type of permission granted the person, organization, or audience.
        /// </summary>
        OneOrMany<DigitalDocumentPermissionType?> PermissionType { get; set; }
    }

    /// <summary>
    /// A permission for a particular person or group to access a particular file.
    /// </summary>
    [DataContract]
    public partial class DigitalDocumentPermission : Intangible, IDigitalDocumentPermission, IEquatable<DigitalDocumentPermission>
    {
        /// <summary>
        /// Gets the name of the type as specified by schema.org.
        /// </summary>
        [DataMember(Name = "@type", Order = 1)]
        public override string Type => "DigitalDocumentPermission";

        /// <summary>
        /// The person, organization, contact point, or audience that has been granted this permission.
        /// </summary>
        [DataMember(Name = "grantee", Order = 206)]
        [JsonConverter(typeof(ValuesJsonConverter))]
        public Values<IAudience, IContactPoint, IOrganization, IPerson> Grantee { get; set; }

        /// <summary>
        /// The type of permission granted the person, organization, or audience.
        /// </summary>
        [DataMember(Name = "permissionType", Order = 207)]
        [JsonConverter(typeof(ValuesJsonConverter))]
        public OneOrMany<DigitalDocumentPermissionType?> PermissionType { get; set; }

        /// <inheritdoc/>
        public bool Equals(DigitalDocumentPermission other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Type == other.Type &&
                this.Grantee == other.Grantee &&
                this.PermissionType == other.PermissionType &&
                base.Equals(other);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this.Equals(obj as DigitalDocumentPermission);

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Of(this.Type)
            .And(this.Grantee)
            .And(this.PermissionType)
            .And(base.GetHashCode());
    }
}
