﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisClient
{
    class Program
    {
        static void Main(string[] args)
        {

            RedisUtil redisUtil = new RedisUtil();
            redisUtil.CreateSampleString();
        }
    }
}
