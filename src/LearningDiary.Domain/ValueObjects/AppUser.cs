using LearningDiary.Domain.Common;
using System;
using System.Collections.Generic;

namespace LearningDiary.Domain.ValueObjects
{
    public class AppUser : ValueObject<AppUser>
    {
        public string Nickname { get; }

        public AppUser(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
                throw new ArgumentException("Nickname cannot be null or empty string");
            Nickname = nickname;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Nickname;
        }
    }
}
