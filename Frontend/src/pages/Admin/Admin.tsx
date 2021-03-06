import React from "react";
import { RouteComponentProps, Redirect } from "react-router-dom";
import { useUser } from "../../providers/UserProvider";
import AdminSidebar from "../../components/Admin/AdminSidebar";
import AdminEditUser from "../../components/Admin/Users/AdminEditUser";
import AdminEditCrowdaction from "../../components/Admin/Crowdactions/AdminEditCrowdaction";
import AdminListUsers from "../../components/Admin/Users/AdminListUsers";
import AdminListCrowdactions from "../../components/Admin/Crowdactions/AdminListCrowdactions";
import { Helmet } from "react-helmet";
import AdminListComments from "../../components/Admin/Comments/AdminListComments";

type TParams = {
  type: string;
  action: string;
  id: string | undefined;
}

const AdminPage = ({ match } : RouteComponentProps<TParams>): any => {
  const user = useUser();

  const adminInner = () => {
    if (match.params.action === "list") {
      if (match.params.type === "crowdactions") {
        return <AdminListCrowdactions />;
      } else if (match.params.type === "users") {
        return <AdminListUsers />;
      } else if (match.params.type === "comments") {
        return <AdminListComments />;
      }
    } else if (match.params.action === "edit" && match.params.id !== undefined) {
      if (match.params.type === "crowdactions") {
        return <AdminEditCrowdaction crowdactionId={match.params.id} />;
      } else if (match.params.type === "users") {
        return <AdminEditUser userId={match.params.id} />;
      }
    }
    return <Redirect to="/404" />;
  };

  return <AdminSidebar>
    <Helmet>
      <title>Admin</title>
      <meta name="description" content="Admin" />
    </Helmet>
    { user?.isAdmin ? adminInner() : <h1>Not allowed</h1> }
  </AdminSidebar>;
};

export default AdminPage;