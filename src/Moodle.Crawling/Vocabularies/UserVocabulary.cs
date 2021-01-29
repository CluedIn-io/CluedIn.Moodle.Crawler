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
            KeyPrefix = "moodle.person";
            KeySeparator = ".";
            Grouping = EntityType.Person;

            AddGroup("Moodle User Details", group =>
            {
                Id = group.Add(
                    new VocabularyKey("Moodle_UserId", VocabularyKeyDataType.Identifier, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Moodle_UserID")
                    .WithDescription("Moodle UserID som er en integer og ikke unikt for systemet")
                );
                IdNumber = group.Add(
                    new VocabularyKey("IdNumber", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible)
                );
                Username = group.Add(
                    new VocabularyKey("Brugernavn", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Brugernavn")
                );
                FirstName = group.Add(
                    new VocabularyKey("Fornavn", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Fornavn")
                );
                LastName = group.Add(
                    new VocabularyKey("Efternavn", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Efternavn")
                );
                Email = group.Add(
                    new VocabularyKey("E-mail", VocabularyKeyDataType.Email, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("E-mail")
                );
                Auth = group.Add(
                    new VocabularyKey("Auth", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible)
                );
                Language = group.Add(
                    new VocabularyKey("Language", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible)
                );
                Department = group.Add(
                    new VocabularyKey("Department", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Afdeling")
                );
                AlternateName = group.Add(
                    new VocabularyKey("AlternateName", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible)
                );
                Slutdato = group.Add(
                    new VocabularyKey("Slutdato", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Slutdato")
                    .WithDescription("Hvornår adgangen til systemet afsluttes")
                );
                UniLogin = group.Add(
                    new VocabularyKey("UniLogin", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible)
                );
                LinkedIn = group.Add(
                    new VocabularyKey("Moodle_LinkedIn", VocabularyKeyDataType.Uri, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Moodle_LinkedIn")
                    .WithDescription("Link til brugerens LinkedIn")
                );
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
