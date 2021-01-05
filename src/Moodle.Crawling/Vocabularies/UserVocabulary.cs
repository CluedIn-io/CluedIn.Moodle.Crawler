using System;
using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.Moodle.Vocabularies
{
    public class UserVocabulary : SimpleVocabulary
    {

        public UserVocabulary()
        {
            VocabularyName = "Moodle User";
            KeyPrefix = "moodle.user";
            KeySeparator = ".";
            Grouping = EntityType.Infrastructure.User;

            AddGroup("Moodle User Details", group =>
            {
                Id = group.Add(new VocabularyKey("Id", VocabularyKeyDataType.Identifier, VocabularyKeyVisibility.Visible));
                IdNumber = group.Add(new VocabularyKey("IdNumber", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Username = group.Add(new VocabularyKey("Username", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                FirstName = group.Add(new VocabularyKey("FirstName", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible));
                LastName = group.Add(new VocabularyKey("LastName", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible));
                Email = group.Add(new VocabularyKey("Email", VocabularyKeyDataType.Email, VocabularyKeyVisibility.Visible));
                Auth = group.Add(new VocabularyKey("Auth", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Language = group.Add(new VocabularyKey("Language", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Department = group.Add(new VocabularyKey("Department", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                AlternateName = group.Add(new VocabularyKey("AlternateName", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Slutdato = group.Add(new VocabularyKey("Slutdato", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible));
                UniLogin = group.Add(new VocabularyKey("UniLogin", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                LinkedIn = group.Add(new VocabularyKey("LinkedIn", VocabularyKeyDataType.Uri, VocabularyKeyVisibility.Visible));
            });

            AddMapping(Id, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneMoodle.UserID);
            AddMapping(Username, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Brugernavn);
            AddMapping(FirstName, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Fornavn);
            AddMapping(LastName, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Efternavn);
            AddMapping(Email, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Email);
            AddMapping(Department, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Afdeling);
            AddMapping(LinkedIn, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.LinkedIn);
        }

        public VocabularyKey Id { get; set; }
        public VocabularyKey IdNumber { get; set; }
        public VocabularyKey Username { get; set; }
        public VocabularyKey FirstName { get; set; }
        public VocabularyKey LastName { get; set; }
        public VocabularyKey Email { get; set; }
        public VocabularyKey Auth { get; set; }
        public VocabularyKey Language { get; set; }
        public VocabularyKey Department { get; set; }
        public VocabularyKey AlternateName { get; set; }
        public VocabularyKey Slutdato { get; set; }
        public VocabularyKey UniLogin { get; set; }
        public VocabularyKey LinkedIn { get; set; }

    }
}
