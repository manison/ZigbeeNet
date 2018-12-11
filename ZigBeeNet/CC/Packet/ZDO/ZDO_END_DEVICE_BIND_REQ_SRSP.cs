﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZigBeeNet.CC.Packet.ZDO
{
    public class ZDO_END_DEVICE_BIND_REQ_SRSP : ZToolPacket /* implements IRESPONSE,IZDO */
    {
    /// <name>TI.ZPI1.ZDO_END_DEVICE_BIND_REQ_SRSP.Status</name>
    /// <summary>Status</summary>
    public int Status { get; private set; }

    /// <name>TI.ZPI1.ZDO_END_DEVICE_BIND_REQ_SRSP</name>
    /// <summary>Constructor</summary>
    public ZDO_END_DEVICE_BIND_REQ_SRSP()
    {
    }

    public ZDO_END_DEVICE_BIND_REQ_SRSP(byte[] framedata)
    {
        this.Status = framedata[0];
        BuildPacket(new DoubleByte(ZToolCMD.ZDO_END_DEVICE_BIND_REQ_SRSP), framedata);
    }

    public override string ToString()
    {
        return "ZDO_END_DEVICE_BIND_REQ_SRSP{" + "Status=" + Status + '}';
    }
}
}
