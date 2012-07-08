namespace aspConf.Controllers.Models {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Caching;
    using aspConf.Model;

    public class ConfRepository {
        public ConfRepository() {
            Context = new ConfContext();
        }

        public ConfContext Context { get; protected set; }

        public void ClearCache() {
            var cache = HttpContext.Current.Cache;
            var keys = (from DictionaryEntry item in cache 
                            where item.Key.ToString().StartsWith("System.Collections.") 
                            select item.Key as string)
                        .ToList();

            foreach (var key in keys) {
                cache.Remove(key);
            }
        }

        public IList<Session> GetActiveSessions() {
            Func<IList<Session>> sessionSource = () => 
                Context.Sessions
                    .Where(sp => sp.IsActive)
                    .ToList();

            return GetFromCache(sessionSource);
        }

        public IList<Speaker> GetActiveSpeakers() {
            Func<IList<Speaker>> speakerSource = () => {
                using (var context = Context) {
                    return context.Speakers
                        .Where(sp => sp.IsActive)
                        .ToList();
                }
            };

            return GetFromCache(speakerSource);
        }

        public IList<Sponsor> GetActiveSposors() {
            Func<IList<Sponsor>> sponsorSource = () => {
                using (var context = Context) {
                    return context.Sponsors
                        .Where(sp => sp.IsActive)
                        .ToList();
                }
            };

            return GetFromCache(sponsorSource);
        }

        protected IList<T> GetFromCache<T>(Func<IList<T>> source) {
            var cache = HttpContext.Current.Cache;
            var keyName = typeof(IList<T>).FullName;
            var result = cache[keyName] as IList<T>;

            if (result == null) {
                result = source();
                cache.Add(keyName, result, null, DateTime.Now.AddHours(12),
                          Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }

            return result;
        }
    }
}