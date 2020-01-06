/*
	Please place this file in src/mbedtls of the GameSaprks SDK release.
	The usual PS4 NDA applies.
*/

#include <net.h>

int doResolverNtoa(const char *hostname, SceNetInAddr *addr)
{
	SceNetId rid = -1;
	int memid = -1;
	int ret;

	ret = sceNetPoolCreate(__FUNCTION__, 4 * 1024, 0);
	if (ret < 0) {
		printf("sceNetPoolCreate() failed (0x%x errno=%d)\n",
			ret, sce_net_errno);
		goto failed;
	}
	memid = ret;
	ret = sceNetResolverCreate("resolver", memid, 0);
	if (ret < 0) {
		printf("sceNetResolverCreate() failed (0x%x errno=%d)\n",
			ret, sce_net_errno);
		goto failed;
	}
	rid = ret;
	ret = sceNetResolverStartNtoa(rid, hostname, addr, 0, 0, 0);
	if (ret < 0) {
		printf("sceNetResolverStartNtoa() failed (0x%x errno=%d)\n",
			ret, sce_net_errno);
		goto failed;
	}
	ret = sceNetResolverDestroy(rid);
	if (ret < 0) {
		printf("sceNetResolverDestroy() failed (0x%x errno=%d)\n",
			ret, sce_net_errno);
		goto failed;
	}
	ret = sceNetPoolDestroy(memid);
	if (ret < 0) {
		printf("sceNetPoolDestroy() failed (0x%x errno=%d)\n",
			ret, sce_net_errno);
		goto failed;
	}
	return 0;

failed:
	sceNetResolverDestroy(rid);
	sceNetPoolDestroy(memid);
	return ret;
}

int mbedtls_net_connect(mbedtls_net_context *ctx, const char *host, const char *port, int proto)
{
	int ret;
	struct sockaddr_in addr_in;

	int ai_family = AF_INET;
	int ai_socktype = proto == MBEDTLS_NET_PROTO_UDP ? SOCK_DGRAM : SOCK_STREAM;
	int ai_protocol = proto == MBEDTLS_NET_PROTO_UDP ? IPPROTO_UDP : IPPROTO_TCP;

	if ((ret = net_prepare()) != 0)
		return(ret);

	memset(&addr_in, 0, sizeof(addr_in));

	if (doResolverNtoa(host, (SceNetInAddr *)&addr_in.sin_addr) != 0)
		return(MBEDTLS_ERR_NET_UNKNOWN_HOST);

	//addr_in.sin_addr.s_addr = sceNetHtonl(addr_in.sin_addr.s_addr);

	addr_in.sin_family = AF_INET;
	addr_in.sin_port = sceNetHtons(atoi(port));

	ctx->fd = (int)socket(ai_family, ai_socktype, ai_protocol);

	if (ctx->fd < 0)
		return MBEDTLS_ERR_NET_SOCKET_FAILED;

	if (connect(ctx->fd, (struct sockaddr*)&addr_in, sizeof(addr_in)) == 0)
		return(0);

	close(ctx->fd);
	ctx->fd = -1;

	return(MBEDTLS_ERR_NET_CONNECT_FAILED);
}

int orbis_set_socket_blocking(int fd)
{
	int optval = 0;
	return sceNetSetsockopt(fd, SCE_NET_SOL_SOCKET, SCE_NET_SO_NBIO, &optval, sizeof(optval));
}

int orbis_set_socket_non_blocking(int fd)
{
	int optval = 1;
	return sceNetSetsockopt(fd, SCE_NET_SOL_SOCKET, SCE_NET_SO_NBIO, &optval, sizeof(optval));
}
