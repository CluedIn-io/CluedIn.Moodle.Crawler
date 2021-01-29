using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.Helpers;
using CluedIn.Crawling.Moodle.Core.Models;
using CluedIn.Crawling.Moodle.Vocabularies;

namespace CluedIn.Crawling.Moodle.ClueProducers
{
    public class UserClueProducer : BaseClueProducer<User>
    {
        private IClueFactory _factory;
        
        public UserClueProducer(IClueFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _factory = factory;
        }

        protected override Clue MakeClueImpl(User input, Guid accountId)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var clue = _factory.Create(EntityType.Person, input.Id.ToString(), accountId);

            var data = clue.Data.EntityData;

            if (!string.IsNullOrWhiteSpace(input.FirstName) && !string.IsNullOrWhiteSpace(input.LastName))
                data.Name = $"{input.FirstName} {input.LastName}";

            if (!string.IsNullOrWhiteSpace(input.Email))
                data.Aliases.Add(input.Email);

            if (!data.OutgoingEdges.Any())
                _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);

            var vocab = new UserVocabulary();
            data.Properties[vocab.Id] = input.Id.PrintIfAvailable();
            data.Properties[vocab.Username] = input.Username.PrintIfAvailable();
            data.Properties[vocab.FirstName] = input.FirstName.PrintIfAvailable();
            data.Properties[vocab.LastName] = input.LastName.PrintIfAvailable();
            data.Properties[vocab.Email] = input.Email.PrintIfAvailable();
            data.Properties[vocab.Department] = input.Department.PrintIfAvailable();

            // Custom fields
            foreach (var field in input.CustomFields)
            {
                if (!string.IsNullOrWhiteSpace(field.Value) && field.Value != "ikke defineret")
                {
                    var key = $"{vocab.KeyPrefix}{vocab.KeySeparator}{field.ShortName}";
                    data.Properties[key] = field.Value.PrintIfAvailable();
                }
            }

            return clue;
        }

    }
}
