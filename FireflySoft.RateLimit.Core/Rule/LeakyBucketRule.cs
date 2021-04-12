using System;
using System.Collections.Generic;

namespace FireflySoft.RateLimit.Core.Rule
{
    /// <summary>
    /// the rule of leaky bucket algorithm
    /// </summary>
    public class LeakyBucketRule : RateLimitRule
    {
        /// <summary>
        /// The capacity of current leaky bucket
        /// </summary>
        public long Capacity { get; private set; }

        /// <summary>
        /// The outflow quantity per unit time
        /// </summary>
        public long OutflowQuantityPerUnit { get; private set; }

        /// <summary>
        /// The time unit of outflow from the leaky bucket
        /// </summary>
        public TimeSpan OutflowUnit { get; private set; }

        /// <summary>
        /// create a new instance
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="outflowQuantityPerUnit"></param>
        /// <param name="outflowUnit"></param>
        public LeakyBucketRule(long capacity, long outflowQuantityPerUnit, TimeSpan outflowUnit)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("the capacity can not less than 1.");
            }

            if (outflowQuantityPerUnit < 1)
            {
                throw new ArgumentException("the outflow quantity per unit can not less than 1.");
            }

            if (outflowUnit.TotalMilliseconds < 1)
            {
                throw new ArgumentException("the outflow unit can not less than 1ms.");
            }

            Capacity = capacity;
            OutflowQuantityPerUnit = outflowQuantityPerUnit;
            OutflowUnit = outflowUnit;
        }
    }
}
