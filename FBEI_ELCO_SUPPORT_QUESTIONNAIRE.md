# ELCO FBEI-0032N-TS EtherNet/IP Output Issue - Vendor Support Questions

## 1. Summary
We are using ELCO FB20 EtherNet/IP modules.

- Input module: `FBEI-3200N-TS`, IP `192.168.250.10`, Product Code `35`
- Output module: `FBEI-0032N-TS`, IP `192.168.250.11`, Product Code `37`
- Vendor ID: `1232`
- PC scanner IP: `192.168.250.1`

The input module works correctly. The output module accepts ForwardOpen, and the PC sends cyclic O->T UDP packets, but the output channel LEDs and physical outputs do not turn ON.

## 2. Current Symptom
For `FBEI-0032N-TS`:

- Explicit messaging works.
- ForwardOpen for Exclusive Owner succeeds.
- O->T UDP packets are sent every 20 ms.
- O->T Connection ID matches the ForwardOpen response.
- Run/Idle header is RUN.
- Output data is present: `FF 00 00 00`.
- However, Q1~Q8 LEDs do not turn ON.
- BF LED remains red.
- Diagnostic T->O data stays all zero.
- Output power diagnostic byte8 bit0 is `0`, so field power appears normal.
- Short circuit and overload diagnostics are all zero.
- Explicit read of Configuration Assembly instance `102` / `0x66` succeeds and returns 2 bytes: `00 00`.

According to the manual, Q LEDs indicate channel logic level. Therefore, if Q LEDs do not turn ON, the module is not applying the received output process data.

## 3. EDS / Assembly Information Used
EDS file: `FBEI-0032N-TS-V1.03.EDS`

Connection path:

```text
20 04 24 66 2C 64 2C 65
```

Decoded:

```text
Class 0x04 Assembly Object
Config Assembly Instance 0x66 / 102
O->T Output Assembly Instance 0x64 / 100
T->O Input Assembly Instance 0x65 / 101
```

Manual says for `FBEI-0032N-TS`:

```text
Input  instance 101, length 10 bytes
Output instance 100, length 4 bytes
```

Output process data:

```text
Byte 0: Q1~Q8
Byte 1: Q9~Q16
Byte 2: Q17~Q24
Byte 3: Q25~Q32
```

Explicit read result:

```text
GetAttributeSingle(Class 0x04, Instance 0x66, Attribute 3)
Length = 2 bytes
Data   = 00 00
```

We also tested explicit writes to Configuration Assembly `0x66`:

```text
SetAttributeSingle(4, 0x66, 3, 00 00) -> readback 00 00
SetAttributeSingle(4, 0x66, 3, FF FF) -> readback FF FF
Restored to 00 00 after test
```

ForwardOpen still succeeds after these writes, but the output does not apply.

## 4. Tested ForwardOpen Parameters
The only O->T format accepted by the module is:

```text
O->T instance: 100
O->T application data length: 4 bytes
O->T real-time format: Header32Bit
O->T network connection size: 10 bytes
T->O instance: 101
T->O length: 10 bytes
RPI: 20 ms
Priority: Scheduled
Transport Class: Class 1 cyclic
```

Rejected tests:

| Test | Result |
| --- | --- |
| O->T Modeless, app length 4, connection size 6 | ForwardOpen rejected, Additional Status `0x127` |
| O->T Header32Bit, advertised connection size 4 | ForwardOpen rejected, Additional Status `0x127` |
| O->T Header32Bit, advertised connection size 8 | ForwardOpen rejected, Additional Status `0x127` |
| Transport Type/Trigger `0x02` | ForwardOpen rejected, Additional Status `0x11C` |
| T->O Multicast instead of Point-to-Point | ForwardOpen succeeds, but output still does not work |

## 5. Packet Capture Facts
Packet capture confirms the PC sends valid-looking Class 1 O->T packets.

ForwardOpen response:

```text
O->T CID = 13 b7 57 ba
T->O CID = 73 47 ce 06
```

UDP O->T packet:

```text
192.168.250.1:2222 -> 192.168.250.11:2222

CPF:
02 00                         Item count
02 80 08 00                   Sequenced Address Item
13 b7 57 ba                   O->T CID
xx xx xx xx                   sequence count
b1 00 0a 00                   Connected Data Item, length 10
ss ss                         data sequence count
01 00 00 00                   Run/Idle header = RUN
ff 00 00 00                   Output data, Q1~Q8 ON
```

Even with this packet stream, Q LEDs do not turn ON.

## 6. Questions for ELCO Support
Please confirm the exact EtherNet/IP scanner configuration required for `FBEI-0032N-TS`.

1. What is the correct Exclusive Owner connection configuration for `FBEI-0032N-TS`?
   - O->T assembly instance?
   - T->O assembly instance?
   - Configuration assembly instance?
   - O->T real-time format?
   - T->O real-time format?
   - O->T connection size?
   - T->O connection size?

2. Does `FBEI-0032N-TS` require a non-empty Configuration Assembly at instance `102` / `0x66`?
   - We confirmed it exists and has 2 bytes.
   - Current/default value appears to be `00 00`.
   - What is the exact byte layout and required value?
   - Which value enables output operation?

3. The module rejects O->T connection size `4`, `6`, and `8`, but accepts `10`.
   - Does the module require O->T size `10` because it expects:
     - 2-byte sequence count
     - 4-byte Run/Idle header
     - 4-byte output data?
   - If yes, why does it not apply the output data after accepting this connection?

4. Does the output module require a PLC-specific ownership/configuration step before applying O->T data?
   - For example, Omron Sysmac setting, keying, configuration data, or a vendor-specific object write?

5. BF LED remains red even after ForwardOpen succeeds and cyclic I/O packets flow.
   - Does BF red mean the module has not accepted the scanner configuration?
   - Which exact parameter causes BF red in this condition?

6. Can ELCO provide a known-good Wireshark/pcap capture or exact Omron/Sysmac configuration for `FBEI-0032N-TS`?
   - ForwardOpen request/response
   - O->T cyclic packet
   - Any configuration data sent before I/O starts

7. Is there any firmware version issue for `FBEI-0032N-TS` where ForwardOpen succeeds but O->T output data is ignored?

8. Please confirm the exact Identity Object values for the tested unit.
   - Vendor ID `1232`?
   - Product Code `37`?
   - Product Name `FBEI-0032N-TS`?
   - Major / Minor firmware revision?
   - Does this firmware revision match EDS `FBEI-0032N-TS-V1.03.EDS`?
   - Has any EDS or firmware revision changed assembly instances, sizes, or configuration data?

9. If Configuration Assembly instance `102` requires data, where is that data defined?
   - Is it documented in the EDS `Params`, `Assembly`, or another section?
   - What is the expected byte count?
   - What are the default bytes in hex?
   - Are non-zero default values required for output enable, safe state, output behavior, or channel mode?

10. Does the module have a safe-state, controller ownership, or run-enable condition that must be cleared before O->T output data is applied?
   - Is any explicit vendor-specific object write required?
   - Is any PLC-specific setup required in Omron Sysmac or another scanner?
   - Which condition makes BF LED change from red to green?

## 7. Requested Answer Format
Please provide either:

```text
O->T instance =
O->T application data length =
O->T network connection size =
O->T real-time format =
T->O instance =
T->O length =
T->O real-time format =
Config instance =
Config data bytes =
Config data byte count =
Config data bytes in hex =
RPI range =
Connection type: P2P or Multicast =
Transport type/trigger =
BF LED clears when =
Required explicit/vendor-specific writes =
```

or a screenshot/export of a working PLC configuration.
