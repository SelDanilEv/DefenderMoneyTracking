import {
  Box,
  Typography,
  Tooltip,
  IconButton,
  Checkbox,
  Grid,
  Button,
  Divider,
  Card,
  FormControlLabel
} from '@mui/material';
import ArrowBackTwoToneIcon from '@mui/icons-material/ArrowBackTwoTone';
import SaveIcon from '@mui/icons-material/Save';
import { connect } from 'react-redux';
import { useState } from 'react';

import EditFromUser from './EditFromUser';

import { UserInfo } from 'src/models/user_info';
import APICallWrapper from 'src/api/APIWrapper/APICallWrapper';
import apiUrls from 'src/api/apiUrls';
import useUtils from 'src/appUtils';


const UpdateUserPage = (props: any) => {
  const u = useUtils()

  const currentUser = {
    ...props.currentUser
  };

  const [user, setUser] = useState<UserInfo>(currentUser);

  const [approve, setApprove] = useState<boolean>(false);

  const handleUpdateUser = () => {
    const requestBody = {
      name: user.name,
      email: user.email,
    }

    APICallWrapper(
      {
        url: apiUrls.accountinfo.update,
        options: {
          method: 'PUT',
          headers: {
            "Content-Type": "application/json"
          },
          body: JSON.stringify(requestBody),
        }
      }
    )
  }

  return (
    <>
      <Box display="flex" mb={3}>
        <Tooltip arrow placement="top" title="Go back">
          <IconButton onClick={() => u.react.navigate("/home")} color="primary" sx={{ p: 2, mr: 2 }}>
            <ArrowBackTwoToneIcon />
          </IconButton>
        </Tooltip>
        <Grid container alignContent={"center"}>
          <Typography variant="h3" component="h3">
            {u.t("personal_ingo_page_title")} <i>{user.id}</i>
          </Typography>
        </Grid>
      </Box>

      <Grid item xs={12}>
        <Card>
          <Box
            p={3}
            display="flex"
            alignItems="center"
            justifyContent="space-between"
          >
            <Box>
              <Typography variant="h3">
                {u.t("personal_ingo_page_account_info")}
              </Typography>
            </Box>
            <Box>
              <FormControlLabel control={
                <Checkbox checked={approve}
                  onChange={() => setApprove(!approve)} />}
                label={u.t("personal_ingo_page_approve")} />
              <Button
                disabled={!approve}
                onClick={() => handleUpdateUser()}
                variant="text"
                startIcon={<SaveIcon />}>
                {u.t("personal_ingo_page_save")}
              </Button>
            </Box>
          </Box>
          <Divider />
          {
            <EditFromUser user={user} updateUser={setUser} />
          }
        </Card>
      </Grid>
    </>
  );
}

const mapStateToProps = (state: any) => {
  return {
    currentUser: state.auth.user
  };
};


export default
  connect(mapStateToProps)
    (UpdateUserPage);
