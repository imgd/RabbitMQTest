using System;
//
/// <summary>
/// snowflake 是 twitter 开源的分布式ID生成算法
/// 其核心思想为，一个long型的ID:
/// 1 bit 占位，不使用
/// 41 bit 作为毫秒数 - 41位的长度可以使用69年
/// 8 bit 系统ID 支持 255个系统
/// 5 bit 节点ID 支持 31个节点
/// 9 bit 作为毫秒内序列号 9位毫秒内产生511个ID序号  每秒支持511*1000=51.1万 ID
/// 
/// snowflake-64bit 示意图：
/// ###########################################################################################################
/// #                                                                                                         #
/// #             0  -  00000000000000000000000000000000000000000   -  00000000   - 00000    -  000000000     #
/// #             ↓                          ↓                            ↓           ↓             ↓         #
/// #        1位符号位                  41位时间戳                     8位系统ID    5位节点id     9位序列号      #
/// #                                                                                                         #
/// ###########################################################################################################
/// </summary>
///

namespace Common
{
    /// <summary>
    /// From: https://github.com/twitter/snowflake
    /// 雪花分布式ID生成算法
    /// </summary>
    public class Snowflake64
    {
        /// <summary>
        /// 节点ID
        /// </summary>
        private long _WorkerId { get; set; }
        /// <summary>
        /// 系统ID
        /// </summary>
        private long _SystemId { get; set; }
        /// <summary>
        /// 序列
        /// </summary>
        private long _Sequence { get; set; } = 0L;

        /// <summary>
        /// 开始时间(69年以此时间为原点)
        /// </summary>
        private long _BeginTimeSpan { get; set; } = (long)(new DateTime(2019, 3, 21, 0, 0, 0, DateTimeKind.Utc) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

        /// <summary>
        /// 节点占位数
        /// </summary>
        private long _WorkerIdBits { get; set; } = 5L;
        /// <summary>
        /// 系统占位数
        /// </summary>
        private long _SystemIdBits { get; set; } = 8L;
        /// <summary>
        /// 最大支持节点ID
        /// </summary>
        private long _MaxWorkerId { get; set; }
        /// <summary>
        /// 最大支持系统ID
        /// </summary>
        private long _MaxSystemId { get; set; }
        /// <summary>
        /// 序列占位数
        /// </summary>
        private long _SequenceBits { get; set; } = 9L;

        /// <summary>
        /// 节点移动数
        /// </summary>
        private long _WorkerIdShift { get; set; }
        /// <summary>
        /// 系统移动数
        /// </summary>
        private long _SystemIdShift { get; set; }
        /// <summary>
        /// timespan占位数
        /// </summary>
        private long _TimestampLeftShift { get; set; }
        /// <summary>
        /// 序列标示
        /// </summary>
        private long _SequenceMask { get; set; }

        private long _LastTimestamp { get; set; } = -1L;
        private static object _SyncRoot { get; set; } = new object();

        private static Snowflake64 _snowflake64 = new Snowflake64();


        /// <summary>
        /// 创建
        /// </summary>
        /// <returns></returns>
        public static long CreateId()
        {
            return _snowflake64.BuildId();
        }

        private Snowflake64()
        {
            _MaxWorkerId = -1L ^ (-1L << (int)_WorkerIdBits);
            _MaxSystemId = -1L ^ (-1L << (int)_SystemIdBits);
            _WorkerIdShift = _SequenceBits;
            _SystemIdShift = _SequenceBits + _WorkerIdBits;
            _TimestampLeftShift = _SequenceBits + _WorkerIdBits + _SystemIdBits;
            _SequenceMask = -1L ^ (-1L << (int)_SequenceBits);
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="systemId">系统ID(支持1-255)</param>
        /// <param name="workerId">节点ID(支持1-31)</param>
        public static void InitData(byte systemId, byte workerId)
        {
            if (workerId > _snowflake64._MaxWorkerId || workerId <= 0)
            {
                throw new ArgumentException(string.Format("worker Id can't be greater than %d or less than 1", _snowflake64._MaxWorkerId));
            }
            if (systemId > _snowflake64._MaxSystemId || systemId <= 0)
            {
                throw new ArgumentException(string.Format("system Id can't be greater than %d or less than 1", _snowflake64._MaxSystemId));
            }
            _snowflake64._WorkerId = workerId;
            _snowflake64._SystemId = systemId;
        }


        /// <summary>
        /// 生成ID
        /// </summary>
        /// <returns></returns>
        private long BuildId()
        {
            lock (Snowflake64._SyncRoot)
            {
                long timestamp = CurrTimespan();

                if (timestamp < _LastTimestamp)
                {
                    throw new ApplicationException(string.Format("Clock moved backwards.  Refusing to generate id for %d milliseconds", _LastTimestamp - timestamp));
                }

                if (_LastTimestamp == timestamp)
                {
                    _Sequence = (_Sequence + 1) & _SequenceMask;
                    if (_Sequence == 0)
                    {
                        timestamp = NextMillis(_LastTimestamp);
                    }
                }
                else
                {
                    _Sequence = 0L;
                }

                _LastTimestamp = timestamp;

                return ((timestamp - _BeginTimeSpan) << (int)_TimestampLeftShift) | (_SystemId << (int)_SystemIdShift) | (_WorkerId << (int)_WorkerIdShift) | _Sequence;
            }
        }

        private long NextMillis(long lastTimestamp)
        {
            long timestamp = CurrTimespan();
            while (timestamp <= lastTimestamp)
            {
                timestamp = CurrTimespan();
            }
            return timestamp;
        }

        private long CurrTimespan()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
    }
}
