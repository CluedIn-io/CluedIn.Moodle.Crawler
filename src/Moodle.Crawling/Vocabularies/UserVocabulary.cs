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
                Department = group.Add(
                    new VocabularyKey("Department", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Afdeling")
                );
                Slutdato = group.Add(
                    new VocabularyKey("Slutdato", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Slutdato")
                    .WithDescription("Hvornår adgangen til systemet afsluttes")
                );
                LinkedIn = group.Add(
                    new VocabularyKey("Moodle_LinkedIn", VocabularyKeyDataType.Uri, VocabularyKeyVisibility.Visible)
                    .WithDisplayName("Moodle_LinkedIn")
                    .WithDescription("Link til brugerens LinkedIn")
                );
            });

            AddMapping(Id, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LedernePerson.Moodle_UserID);
            AddMapping(Username, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Brugernavn);
            AddMapping(FirstName, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Fornavn);
            AddMapping(LastName, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Efternavn);
            AddMapping(Email, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Email);
            AddMapping(Department, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.Afdeling);
            AddMapping(LinkedIn, CluedIn.Lederne.Common.Vocabularies.Vocabularies.LederneBruger.LinkedIn);
        }

        public VocabularyKey Id { get; set; }
        public VocabularyKey Username { get; set; }
        public VocabularyKey FirstName { get; set; }
        public VocabularyKey LastName { get; set; }
        public VocabularyKey Email { get; set; }
        public VocabularyKey Department { get; set; }
        public VocabularyKey Slutdato { get; set; }
        public VocabularyKey LinkedIn { get; set; }

    }
}
