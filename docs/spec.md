# HTTP Specification for Nila

This document defines the subset of **HTTP/1.1** that we implement, with versioning for planned improvements.

**Reference RFCs:**

- [RFC 9110: HTTP/1.1 Semantics](https://www.rfc-editor.org/rfc/rfc9110)
- [RFC 9112: HTTP/1.1 Message Syntax and Routing](https://www.rfc-editor.org/rfc/rfc9112)

---

## v0.1 — Initial (Planned)

### Methods

- [ ] GET — Retrieve resource ([RFC 9110 §9.3](https://www.rfc-editor.org/rfc/rfc9110#section-9.3))
- [ ] POST — Submit data ([RFC 9110 §9.6](https://www.rfc-editor.org/rfc/rfc9110#section-9.6))
- [ ] PUT — Replace resource ([RFC 9110 §9.4](https://www.rfc-editor.org/rfc/rfc9110#section-9.4))
- [ ] DELETE — Delete resource ([RFC 9110 §9.7](https://www.rfc-editor.org/rfc/rfc9110#section-9.7))
- [ ] OPTIONS — Return allowed methods ([RFC 9110 §9.2](https://www.rfc-editor.org/rfc/rfc9110#section-9.2))
- [ ] HEAD — Headers only ([RFC 9110 §9.1](https://www.rfc-editor.org/rfc/rfc9110#section-9.1))
- [ ] TRACE — Not implemented (security risk)
- [ ] CONNECT — Not implemented (proxy / tunneling)

---

### Request Structure

- [X] Start-line parsing ([RFC 9112 §3.1](https://www.rfc-editor.org/rfc/rfc9112#section-3.1))
- [ ] Header parsing ([RFC 9112 §4](https://www.rfc-editor.org/rfc/rfc9112#section-4))
- [ ] Content-Length bodies only ([RFC 9110 §8.3](https://www.rfc-editor.org/rfc/rfc9110#section-8.3))
- [ ] Chunked encoding — planned for future
- [ ] Host header required ([RFC 9110 §5.4](https://www.rfc-editor.org/rfc/rfc9110#section-5.4))

---

### Response Structure

- [X] Status line ([RFC 9110 §6.1](https://www.rfc-editor.org/rfc/rfc9110#section-6.1))
- [X] Headers ([RFC 9110 §6](https://www.rfc-editor.org/rfc/rfc9110#section-6))
- [X] Body optional
- [X] Common status codes only: `200, 201, 204, 400, 404, 405, 500, 501` ([RFC 9110 §15](https://www.rfc-editor.org/rfc/rfc9110#section-15))

---

### Headers (Supported)

- [ ] Host — required ([RFC 9110 §5.4](https://www.rfc-editor.org/rfc/rfc9110#section-5.4))
- [ ] User-Agent ([RFC 9110 §7.5.1](https://www.rfc-editor.org/rfc/rfc9110#section-7.5.1))
- [ ] Accept ([RFC 9110 §7.3.1](https://www.rfc-editor.org/rfc/rfc9110#section-7.3.1))
- [ ] Content-Type ([RFC 9110 §7.2.1](https://www.rfc-editor.org/rfc/rfc9110#section-7.2.1))
- [ ] Content-Length ([RFC 9110 §8.3](https://www.rfc-editor.org/rfc/rfc9110#section-8.3))
- [ ] Connection ([RFC 9110 §6.3.4](https://www.rfc-editor.org/rfc/rfc9110#section-6.3.4))
- [ ] Date (response only) ([RFC 9110 §7.1.1](https://www.rfc-editor.org/rfc/rfc9110#section-7.1.1))
- [ ] Server (response only) ([RFC 9110 §7.4.2](https://www.rfc-editor.org/rfc/rfc9110#section-7.4.2))

**Not supported / deferred:**

- Transfer-Encoding (chunked)
- Keep-Alive header semantics
- Cookies / Set-Cookie
- Authorization / Authentication
- Cache-Control / ETag
- Location / Redirects

---

### Connection Model

- [ ] HTTP/1.1 over TCP ([RFC 9110 §2.7](https://www.rfc-editor.org/rfc/rfc9110#section-2.7))
- [ ] One request per connection, optionally Keep-Alive
- [ ] Pipelining — not implemented

---

### vNext — Future Improvements

- Chunked transfer encoding ([RFC 9110 §8.3.1](https://www.rfc-editor.org/rfc/rfc9110#section-8.3.1))
- Streaming request/response bodies
- Cookie & session handling
- Basic authentication
- TLS / HTTPS support
- HTTP/2 / HTTP/3 support
- Compression (gzip, br)
- Range requests
- Caching / ETag handling

---
